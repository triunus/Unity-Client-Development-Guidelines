using System;
using System.Collections.Generic;

using DesignPattern.Observer;

using Data.Temporay;

namespace Data.Storage.Dynamic
{
    [Serializable]
    public class PlayerStructureInventoryDataNestedRepository : IServerDataJsonConverter
    {
        private ServerDataType serverDataType;

        private Dictionary<BuildingCategoryType, PlayerStructureInventoryDataRepository> playerStructureInventoryDataNestedRepository;

        private IObserverSubject<PlayerStructureInventoryDataNestedRepository> playerStructureInventoryDataNestedRepositoryObserver;

        public PlayerStructureInventoryDataNestedRepository()
        {
            this.serverDataType = ServerDataType.PlayerStructureInventoryDataNestedRepository;

            this.playerStructureInventoryDataNestedRepository = new Dictionary<BuildingCategoryType, PlayerStructureInventoryDataRepository>();

            this.playerStructureInventoryDataNestedRepositoryObserver = new ObserverSubject<PlayerStructureInventoryDataNestedRepository>(ObserverType.PlayerStructureInventoryDataNestedRepository, this);
        }

        public void SetPlayerStructureInventoryData(BuildingCategoryType structureCategoryType, int structureNumber, PlayerStructureInventoryData playerStructureInventoryData)
        {
            this.CreatePlayerStructureInventoryDataRepository(structureCategoryType);

            this.playerStructureInventoryDataNestedRepository[structureCategoryType].SetPlayerStructureInventoryData(structureNumber, playerStructureInventoryData);
        }

        public PlayerStructureInventoryDataRepository GetPlayerStructureInventoryDataRepository(BuildingCategoryType structureCategoryType)
        {
            if (this.playerStructureInventoryDataNestedRepository.ContainsKey(structureCategoryType))
                return this.playerStructureInventoryDataNestedRepository[structureCategoryType];
            else
                return null;
        }
        public PlayerStructureInventoryData GetPlayerStructureInventoryData(BuildingCategoryType structureCategoryType, int structureNumber)
        {
            if (this.playerStructureInventoryDataNestedRepository.ContainsKey(structureCategoryType))
                return this.playerStructureInventoryDataNestedRepository[structureCategoryType].GetPlayerStructureInventoryData(structureNumber);
            else
                return null;
        }

        public void AddPossessionCount(BuildingCategoryType structureCategoryType, int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryDataRepository(structureCategoryType);

            this.playerStructureInventoryDataNestedRepository[structureCategoryType].AddPossessionCount(structureNumber, count);
        }

        public void SubtractPossessionCount(BuildingCategoryType structureCategoryType, int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryDataRepository(structureCategoryType);

            this.playerStructureInventoryDataNestedRepository[structureCategoryType].SubtractPossessionCount(structureNumber, count);
        }

        public void AddPlacedCount(BuildingCategoryType structureCategoryType, int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryDataRepository(structureCategoryType);

            this.playerStructureInventoryDataNestedRepository[structureCategoryType].AddPlacedCount(structureNumber, count);
        }

        public void SubtractPlacedCount(BuildingCategoryType structureCategoryType, int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryDataRepository(structureCategoryType);

            this.playerStructureInventoryDataNestedRepository[structureCategoryType].SubtractPlacedCount(structureNumber, count);
        }

        private void CreatePlayerStructureInventoryDataRepository(BuildingCategoryType structureCategoryType)
        {
            if (!this.playerStructureInventoryDataNestedRepository.ContainsKey(structureCategoryType))
            {
                PlayerStructureInventoryDataRepository newPlayerStructureDataGroup = new PlayerStructureInventoryDataRepository();
                this.playerStructureInventoryDataNestedRepository.Add(structureCategoryType, newPlayerStructureDataGroup);
            }
        }

        public string DataToJson()
        {
            throw new NotImplementedException();
        }

        public void JsonToData(string jsonString)
        {
            throw new NotImplementedException();
        }

        public IObserverSubject<PlayerStructureInventoryDataNestedRepository> PlayerStructureInventoryDataNestedRepositoryObserver { get => playerStructureInventoryDataNestedRepositoryObserver; }
    }

    [Serializable]
    public class PlayerStructureInventoryDataRepository
    {
        private Dictionary<int, PlayerStructureInventoryData> playerStructureInventoryDataRepositorys;

        public PlayerStructureInventoryDataRepository()
        {
            this.playerStructureInventoryDataRepositorys = new Dictionary<int, PlayerStructureInventoryData>();
        }
        public void SetPlayerStructureInventoryData(int structureNumber, PlayerStructureInventoryData playerStructureInventoryData)
        {
            if (this.playerStructureInventoryDataRepositorys.ContainsKey(structureNumber))
                this.playerStructureInventoryDataRepositorys[structureNumber] = playerStructureInventoryData;
            else
            {
                PlayerStructureInventoryData newPlayerStructureData = new PlayerStructureInventoryData(0, 0);
                this.playerStructureInventoryDataRepositorys.Add(structureNumber, newPlayerStructureData);
            }
        }

        public PlayerStructureInventoryData GetPlayerStructureInventoryData(int structureNumber)
        {
            if (this.playerStructureInventoryDataRepositorys.ContainsKey(structureNumber))
                return this.playerStructureInventoryDataRepositorys[structureNumber];
            else
                return null;
        }

        public void AddPossessionCount(int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryData(structureNumber);

            this.playerStructureInventoryDataRepositorys[structureNumber].PossessionCount += count;
        }

        public void SubtractPossessionCount(int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryData(structureNumber);

            if(this.playerStructureInventoryDataRepositorys[structureNumber].AvailableCount >= count)
                this.playerStructureInventoryDataRepositorys[structureNumber].PossessionCount -= count;
        }

        public void AddPlacedCount(int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryData(structureNumber);

            if (this.playerStructureInventoryDataRepositorys[structureNumber].AvailableCount >= count)
                this.playerStructureInventoryDataRepositorys[structureNumber].PlacedCount += count;
        }

        public void SubtractPlacedCount(int structureNumber, int count)
        {
            this.CreatePlayerStructureInventoryData(structureNumber);

            if (this.playerStructureInventoryDataRepositorys[structureNumber].PlacedCount >= count)
                this.playerStructureInventoryDataRepositorys[structureNumber].PlacedCount -= count;
        }

        private void CreatePlayerStructureInventoryData(int structureNumber)
        {
            if (!this.playerStructureInventoryDataRepositorys.ContainsKey(structureNumber))
            {
                PlayerStructureInventoryData newPlayerStructureInventoryData = new PlayerStructureInventoryData(0, 0);
                this.playerStructureInventoryDataRepositorys.Add(structureNumber, newPlayerStructureInventoryData);
            }
        }
    }

    [Serializable]
    public class PlayerStructureInventoryData
    {
        private int possessionCount;
        private int placedCount;

        public PlayerStructureInventoryData(int possessionCount, int placedCount)
        {
            this.possessionCount = possessionCount;
            this.placedCount = placedCount;
        }

        public int PossessionCount { get => possessionCount; set => possessionCount = value; }
        public int PlacedCount { get => placedCount; set => placedCount = value; }
        public int AvailableCount { get => PossessionCount - PlacedCount; }
    }
}