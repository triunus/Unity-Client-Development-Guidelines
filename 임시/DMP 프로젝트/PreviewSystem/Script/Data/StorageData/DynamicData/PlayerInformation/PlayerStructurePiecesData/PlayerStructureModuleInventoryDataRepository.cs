using System.Collections.Generic;

using Data.Temporay;

using DesignPattern.Observer;

namespace Data.Storage.Dynamic
{
    public class PlayerStructureModuleInventoryDataRepository : IServerDataJsonConverter
    {
        private ServerDataType serverDataType;

        Dictionary<BuildingCategoryType, PlayerStructureInventoryData> PlayerStructureInventoryDatas;

        private IObserverSubject<PlayerStructureModuleInventoryDataRepository> playerStructureModuleInventoryDataRepositoryObserver;

        public PlayerStructureModuleInventoryDataRepository()
        {
            this.serverDataType = ServerDataType.PlayerStructureInventoryDataNestedRepository;

            this.PlayerStructureInventoryDatas = new Dictionary<BuildingCategoryType, PlayerStructureInventoryData>();

            this.playerStructureModuleInventoryDataRepositoryObserver = new ObserverSubject<PlayerStructureModuleInventoryDataRepository>(ObserverType.PlayerStructureModuleInventoryDataRepository, this);
        }

        public void SetPlayerStructureInventoryData(BuildingCategoryType structureCategoryType, PlayerStructureInventoryData playerStructureInventoryData)
        {
            if (this.PlayerStructureInventoryDatas.ContainsKey(structureCategoryType))
                this.PlayerStructureInventoryDatas[structureCategoryType] = playerStructureInventoryData;
            else
                this.PlayerStructureInventoryDatas.Add(structureCategoryType, playerStructureInventoryData);
        }

        public PlayerStructureInventoryData GetPlayerStructureInventoryData(BuildingCategoryType structureCategoryType)
        {
            if (this.PlayerStructureInventoryDatas.ContainsKey(structureCategoryType))
                return this.PlayerStructureInventoryDatas[structureCategoryType];
            else
                return null;
        }


        public void AddPossessionCount(BuildingCategoryType structureCategoryType, int count)
        {
            this.CreatePlayerStructureInventoryData(structureCategoryType);

            this.PlayerStructureInventoryDatas[structureCategoryType].PossessionCount += count;
        }

        public void SubtractPossessionCount(BuildingCategoryType structureCategoryType, int count)
        {
            this.CreatePlayerStructureInventoryData(structureCategoryType);

            if (this.PlayerStructureInventoryDatas[structureCategoryType].AvailableCount >= count)
                this.PlayerStructureInventoryDatas[structureCategoryType].PossessionCount -= count;
        }

        public void AddPlacedCount(BuildingCategoryType structureCategoryType, int count)
        {
            this.CreatePlayerStructureInventoryData(structureCategoryType);

            if (this.PlayerStructureInventoryDatas[structureCategoryType].AvailableCount >= count)
                this.PlayerStructureInventoryDatas[structureCategoryType].PlacedCount += count;
        }

        public void SubtractPlacedCount(BuildingCategoryType structureCategoryType, int count)
        {
            this.CreatePlayerStructureInventoryData(structureCategoryType);

            if (this.PlayerStructureInventoryDatas[structureCategoryType].PlacedCount >= count)
                this.PlayerStructureInventoryDatas[structureCategoryType].PlacedCount -= count;
        }

        private void CreatePlayerStructureInventoryData(BuildingCategoryType structureCategoryType)
        {
            if (!this.PlayerStructureInventoryDatas.ContainsKey(structureCategoryType))
            {
                PlayerStructureInventoryData newPlayerStructureInventoryData = new PlayerStructureInventoryData(0, 0);
                this.PlayerStructureInventoryDatas.Add(structureCategoryType, newPlayerStructureInventoryData);
            }
        }

        public string DataToJson()
        {
            throw new System.NotImplementedException();
        }

        public void JsonToData(string jsonString)
        {
            throw new System.NotImplementedException();
        }
    }
}