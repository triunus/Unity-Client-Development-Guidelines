using UnityEngine;

using Data.Temporay;
using DesignPattern.Observer;
using Data;

namespace System.BuildingSystem
{
    public class PreviewObjectGridPositionView_PreviewObject : MonoBehaviour, IObserverSubscriber
    {
        [SerializeField] private PositionConverter positionConverter;

        // StructurePreviewData를 구성할 객체에 대한 정보
        private PreviewSystemData previewObjectData;

        private IObserverSubject<Vector3Int> previousObjectGridPositionObserverSubject;

        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.previousObjectGridPositionObserverSubject = this.previewObjectData.PreviewObjectGridPositionObserverSubject;
        }
        private void OnEnable()
        {
            this.previousObjectGridPositionObserverSubject.RegisterObserver(this);
        }
        private void OnDisable()
        {
            this.previousObjectGridPositionObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.PreviewObjectGridPosition:
                    this.UpdatePreviewObjectByPreviousObjectGridPosition();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePreviewObjectByPreviousObjectGridPosition()
        {
            Vector3Int previewObjectGridPosition = this.previousObjectGridPositionObserverSubject.GetObserverData();
            Vector3 previewObjectWorldPosition = this.positionConverter.ConvertGridCellToWorldPosition(previewObjectGridPosition);

//            Debug.Log($"previewObjectGridPosition : {previewObjectGridPosition}");
//            Debug.Log($"previewObjectWorldPosition : {previewObjectWorldPosition}");


            this.previewObjectData.PreviewStructureObject.transform.position = previewObjectWorldPosition;
            this.previewObjectData.PreviewFloorObject.transform.position = previewObjectWorldPosition;
        }
    }
}