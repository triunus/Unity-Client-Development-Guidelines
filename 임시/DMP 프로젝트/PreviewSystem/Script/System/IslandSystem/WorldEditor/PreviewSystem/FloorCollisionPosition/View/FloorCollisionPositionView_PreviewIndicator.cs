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
        [Tooltip("Indicator 중심을 기점으로 실질적으로 가리키는 위치 지정하기 위한 offset 입니다.")]
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
            // 현재 PreviewObject 위치.
            Vector3Int previewObjectGridPosition = this.previewObjectData.PreviewObjectGridPosition;
            Vector3 previewObjectWorldPosition = this.positionConverter.ConvertGridCellToWorldPosition(previewObjectGridPosition) + new Vector3(1.5f, 0, 1.5f); ;

            // 증가하는 Floor 값.
            float floorLayer = this.floorLayerObserverSubject.GetObserverData();

            // 증가하고 있는 PreviewObject 위치.
            Vector3 previewObjectWorldPositionWithFloor = new Vector3(previewObjectWorldPosition.x, floorLayer, previewObjectWorldPosition.z);
            Vector2 previewObjectScreenPosition = this.positionConverter.ConvertWorldPositionToScreenPosition(previewObjectWorldPositionWithFloor);

            // indicator 중심 위치.
            Vector2 indicatorCenterPosition = previewObjectScreenPosition - new Vector2(0, pointOffset);

            // indicator 위치 지정.
            this.indicator.transform.position = indicatorCenterPosition;
        }
    }
}