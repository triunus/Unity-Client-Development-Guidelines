using UnityEngine;

using Data.Temporay;
using DesignPattern.Observer;
using Data;

namespace System.BuildingSystem
{
    public class FloorCollisionPositionView_EditorBar : MonoBehaviour, IObserverSubscriber
    {
        [SerializeField] private PositionConverter positionConverter;

        private PreviewSystemData previewObjectData;

        private IObserverSubject<float> floorCollisionPositionObserverSubject;

        [SerializeField] private GameObject editorBar;
        [Tooltip("PreviewObject�� ScreenPosiion�� ������������ EditorBar�� �Ÿ��� ���մϴ�.")]
        [SerializeField] private float distanceOffset;


        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.floorCollisionPositionObserverSubject = this.previewObjectData.FloorCollisionPositionObserverSubject;
        }
        private void OnEnable()
        {
            this.floorCollisionPositionObserverSubject.RegisterObserver(this);
        }
        private void OnDisable()
        {
            this.floorCollisionPositionObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.FloorCollisionPosition:
                    this.UpdatePreviewObjectByFloorLayer();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePreviewObjectByFloorLayer()
        {
            // ���� PreviewObject ��ġ.
            Vector3Int previewObjectGridPosition = this.previewObjectData.PreviewObjectGridPosition;
            Vector3 previewObjectWorldPosition = this.positionConverter.ConvertGridCellToWorldPosition(previewObjectGridPosition) + new Vector3(1.5f, 0, 1.5f); ;

            // �����ϴ� Floor ��.
            float floorLayer = this.floorCollisionPositionObserverSubject.GetObserverData();

            // �����ϰ� �ִ� PreviewObject ��ġ.
            Vector3 previewObjectWorldPositionWithFloor = new Vector3(previewObjectWorldPosition.x, floorLayer, previewObjectWorldPosition.z);
            Vector2 previewObjectScreenPosition = this.positionConverter.ConvertWorldPositionToScreenPosition(previewObjectWorldPositionWithFloor);

            // editorBar �߽� ��ġ.
            Vector2 editorBarCenterPosition = previewObjectScreenPosition + new Vector2(0, distanceOffset);

            this.editorBar.transform.position = editorBarCenterPosition;
        }
    }
}