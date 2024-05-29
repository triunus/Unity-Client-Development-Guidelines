using UnityEngine;

using Data.Temporay;
using DesignPattern.Observer;
using Data;

namespace System.BuildingSystem
{
    public class FloorCollisionPositionView_PreviewObject : MonoBehaviour, IObserverSubscriber
    {
        [SerializeField] private PositionConverter positionConverter;

        // StructurePreviewData를 구성할 객체에 대한 정보
        private PreviewSystemData previewObjectData;

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
                    this.UpdatePreviewObjectByFloorLayer();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePreviewObjectByFloorLayer()
        {
            // 현재 PreviewObject 위치.
            Vector3Int previewObjectGridPosition = this.previewObjectData.PreviewObjectGridPosition;
            Vector3 previewObjectWorldPosition = this.positionConverter.ConvertGridCellToWorldPosition(previewObjectGridPosition);

            // 증가하는 Floor 값.
            float floorLayer = this.floorLayerObserverSubject.GetObserverData();

            // 증가하고 있는 PreviewObject 위치.
            Vector3 previewObjectWorldPositionWithFloor = new Vector3(previewObjectWorldPosition.x, floorLayer, previewObjectWorldPosition.z);

            this.previewObjectData.PreviewStructureObject.transform.position = previewObjectWorldPositionWithFloor;
            this.previewObjectData.PreviewFloorObject.transform.position = previewObjectWorldPositionWithFloor;
        }
    }
}