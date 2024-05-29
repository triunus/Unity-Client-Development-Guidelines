using UnityEngine;

using DesignPattern.Observer;

using Data.Temporay;
using Data;

namespace System.BuildingSystem
{
    public class WorldEidtorObjectPlaceableController : MonoBehaviour, IObserverSubscriber
    {
        private IWorldEidtorObjectPlaceableModel worldEidtorObjectPlaceableModel;

        private IObserverSubject<StructureObjectRotationType> structurePreviewRotationObserverSubject;
        private IObserverSubject<Vector3Int> previousObjectGridPositionObserverSubject;

        private void Awake()
        {
            this.worldEidtorObjectPlaceableModel = new WorldEidtorObjectPlaceableModel();

            PreviewSystemData previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.structurePreviewRotationObserverSubject = previewObjectData.StructureObjectRotationTypeObserverSubject;
            this.previousObjectGridPositionObserverSubject = previewObjectData.PreviewObjectGridPositionObserverSubject;
        }
        private void OnEnable()
        {
            this.structurePreviewRotationObserverSubject.RegisterObserver(this);
            this.previousObjectGridPositionObserverSubject.RegisterObserver(this);
        }
        private void OnDisable()
        {
            this.structurePreviewRotationObserverSubject.RemoveObserver(this);
            this.previousObjectGridPositionObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.StructureObjectRotationType:
                    this.UpdatePlaceableData();
                    break;
                case ObserverType.PreviewObjectGridPosition:
                    this.UpdatePlaceableData();
                    break;
                default:
                    break;
            }
        }

        // 0 : ��ġ �� ����, 1 : ��� ����, 2 : ��ġ ����.
        private void UpdatePlaceableData()
        {
            this.worldEidtorObjectPlaceableModel.UpdateWorldEidtorObjectPlaceableData();
        }
    }
}