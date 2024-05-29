using Data;
using Data.Temporay;
using Data.Storage.Dynamic;

namespace System.BuildingSystem
{
    public interface IWorldEidtorObjectPlaceableModel
    {
        public void UpdateWorldEidtorObjectPlaceableData();
    }

    public class WorldEidtorObjectPlaceableModel : IWorldEidtorObjectPlaceableModel
    {
        private CoordinatesValidator coordinatesValidator;

        private PlayerStructureInventoryDataNestedRepository playerStructureDataGroupReference;
        private PlayerStructureModuleInventoryDataRepository playerStructureModuleInventoryDataRepository;

        private PreviewSystemData previewSystemData;

        public WorldEidtorObjectPlaceableModel()
        {
            this.coordinatesValidator = new CoordinatesValidator();

            this.previewSystemData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.playerStructureDataGroupReference = StorageDynamicData.Instance.PlayerInformation.PlayerStructureInventoryDataNestedRepository;
            this.playerStructureModuleInventoryDataRepository = StorageDynamicData.Instance.PlayerInformation.PlayerStructureModuleInventoryDataRepository;
        }

        public void UpdateWorldEidtorObjectPlaceableData()
        {
            bool tempPlaceable = false;

            bool isCoordinatesAvailable = this.coordinatesValidator.IsAvailableCoordinates(
                this.previewSystemData.PreviewObjectGridPosition, this.previewSystemData.StructureObjectRotationType, this.previewSystemData.Size);

            bool isObjectPlaceable = this.coordinatesValidator.IsPlaceableObject(
                this.previewSystemData.BuildingCategoryType, this.previewSystemData.PreviewObjectGridPosition, this.previewSystemData.StructureObjectRotationType, this.previewSystemData.Size);

            bool hasStock = this.hasSufficientObjectStock();

            if (isCoordinatesAvailable && isObjectPlaceable && hasStock) tempPlaceable = true;
            else tempPlaceable = false;

//            UnityEngine.Debug.Log($"isCoordinatesAvailable : {isCoordinatesAvailable}, isObjectPlaceable : {isObjectPlaceable}, hasStock : {hasStock}");
//            UnityEngine.Debug.Log($"tempPlaceable : {tempPlaceable}");

            this.previewSystemData.WorldEidtorObjectPlaceable = tempPlaceable;
            this.previewSystemData.WorldEidtorObjectPlaceableObserverSubject.NotifySubscribers();
        }

        private bool hasSufficientObjectStock()
        {
            int availableObjectCount = 0;

            if (this.previewSystemData.BuildingCategoryType.Equals(BuildingCategoryType.Tile) || this.previewSystemData.BuildingCategoryType.Equals(BuildingCategoryType.Fence))
            {
                availableObjectCount = this.playerStructureModuleInventoryDataRepository.GetPlayerStructureInventoryData(this.previewSystemData.BuildingCategoryType).AvailableCount;
            }
            else
            {
                availableObjectCount = this.playerStructureDataGroupReference.GetPlayerStructureInventoryData(
                                                                                this.previewSystemData.BuildingCategoryType, this.previewSystemData.StructureNumber).AvailableCount;
            }

            if (availableObjectCount > 0) return true;
            else return false;
        }
    }
}