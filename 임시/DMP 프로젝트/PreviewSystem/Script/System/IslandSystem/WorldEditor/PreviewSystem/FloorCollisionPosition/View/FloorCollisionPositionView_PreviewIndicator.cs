using UnityEngine;

using DesignPattern.Observer;
using Data.Temporay;
using Data;

namespace System.BuildingSystem
{
    public class FloorCollisionPositionView_PreviewIndicator : MonoBehaviour, IObserverSubscriber
    {
        [SerializeField] private PositionConverter positionConverter;

        private PreviewSystemData previewObjectData;

        [SerializeField] private GameObject indicator;
        [Tooltip("Indicator �߽��� �������� ���������� ����Ű�� ��ġ �����ϱ� ���� offset �Դϴ�.")]
        [SerializeField] private float pointOffset;

        private IObserverSubject<float> floorLayerObserverSubject;

        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.floorLayerObserverSubject = this.previewObjectData.FloorCollisionPositionObserverSubject;
        }
        private void OnEnable()
        {
            this.floorLayerObserverSubject.RegisterObserver(this);
        }
        private void OnDisable()
        {
            this.floorLayerObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.FloorCollisionPosition:
                    this.UpdateIndicatorByFloorLayer();
                    break;
                default:
                    break;
            }
        }

        public void UpdateIndicatorByFloorLayer()
        {
            // ���� PreviewObject ��ġ.
            Vector3Int previewObjectGridPosition = this.previewObjectData.PreviewObjectGridPosition;
            Vector3 previewObjectWorldPosition = this.positionConverter.ConvertGridCellToWorldPosition(previewObjectGridPosition) + new Vector3(1.5f, 0, 1.5f); ;

            // �����ϴ� Floor ��.
            float floorLayer = this.floorLayerObserverSubject.GetObserverData();

            // �����ϰ� �ִ� PreviewObject ��ġ.
            Vector3 previewObjectWorldPositionWithFloor = new Vector3(previewObjectWorldPosition.x, floorLayer, previewObjectWorldPosition.z);
            Vector2 previewObjectScreenPosition = this.positionConverter.ConvertWorldPositionToScreenPosition(previewObjectWorldPositionWithFloor);

            // indicator �߽� ��ġ.
            Vector2 indicatorCenterPosition = previewObjectScreenPosition - new Vector2(0, pointOffset);

            // indicator ��ġ ����.
            this.indicator.transform.position = indicatorCenterPosition;
        }
    }
}