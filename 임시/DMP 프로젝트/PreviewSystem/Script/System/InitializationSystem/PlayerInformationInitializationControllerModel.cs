using System.Collections.Generic;

using Data;
using Data.Storage.Dynamic;

namespace System.Initialization
{
    public class PlayerInformationInitializationControllerModel
    {
        public PlayerInformationInitializationControllerModel()
        {
            this.TempPlayerStructureInventoryDataNestedRepository();
            this.TempPlayerStructureModuleInventoryDataRepository();
            this.TempPlacedObjectDataRepository();
        }


        // 유저가 보유한 객체들에 정보를 추가한 것.
        private void TempPlayerStructureInventoryDataNestedRepository()
        {
            PlayerStructureInventoryDataNestedRepository playerStructureInventoryDataNestedRepository = StorageDynamicData.Instance.PlayerInformation.PlayerStructureInventoryDataNestedRepository;

            // Building
            playerStructureInventoryDataNestedRepository.AddPossessionCount(BuildingCategoryType.Structure, 0, 5);
            playerStructureInventoryDataNestedRepository.AddPossessionCount(BuildingCategoryType.Structure, 1, 3);
            playerStructureInventoryDataNestedRepository.AddPossessionCount(BuildingCategoryType.Structure, 2, 3);
            playerStructureInventoryDataNestedRepository.AddPossessionCount(BuildingCategoryType.Structure, 3, 2);
            playerStructureInventoryDataNestedRepository.AddPossessionCount(BuildingCategoryType.Structure, 4, 1);

            // Tree
            playerStructureInventoryDataNestedRepository.AddPossessionCount(BuildingCategoryType.Tree, 0, 5);

            // Grass
            playerStructureInventoryDataNestedRepository.AddPossessionCount(BuildingCategoryType.Grass, 0, 5);
        }
        private void TempPlayerStructureModuleInventoryDataRepository()
        {
            PlayerStructureModuleInventoryDataRepository playerStructureModuleInventoryDataRepository = StorageDynamicData.Instance.PlayerInformation.PlayerStructureModuleInventoryDataRepository;

            // Tile
            playerStructureModuleInventoryDataRepository.AddPossessionCount(BuildingCategoryType.Tile, 30);

            // Fence
            playerStructureModuleInventoryDataRepository.AddPossessionCount(BuildingCategoryType.Fence, 10);
        }

        // 유저가 과거에 배치했던 객체들에 대한 정보을 추가한 것.
        private void TempPlacedObjectDataRepository()
        {
            PlacedObjectDataRepository placedObjectDataRepositorys = StorageDynamicData.Instance.PlayerInformation.PlacedObjectDataRepository;

            List<PlacedObjectData> placedObjectDatas = new List<PlacedObjectData>();

            // 모서리 4개
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-2, 2, 1), BuildingCategoryType.Tile, 3));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-2, -2, 1), BuildingCategoryType.Tile, 9));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(2, 2, 1), BuildingCategoryType.Tile, 6));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(2, -2, 1), BuildingCategoryType.Tile, 12));

            // 가장자리 3개 * 4개
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-2, 1, 1), BuildingCategoryType.Tile, 11));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-2, 0, 1), BuildingCategoryType.Tile, 11));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-2, -1, 1), BuildingCategoryType.Tile, 11));

            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(2, 1, 1), BuildingCategoryType.Tile, 14));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(2, 0, 1), BuildingCategoryType.Tile, 14));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(2, -1, 1), BuildingCategoryType.Tile, 14));

            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(1, 2, 1), BuildingCategoryType.Tile, 7));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(0, 2, 1), BuildingCategoryType.Tile, 7));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-1, 2, 1), BuildingCategoryType.Tile, 7));

            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(1, -2, 1), BuildingCategoryType.Tile, 13));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(0, -2, 1), BuildingCategoryType.Tile, 13));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-1, -2, 1), BuildingCategoryType.Tile, 13));

            // 안쪽 9개
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-1, 1, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-1, 0, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(-1, -1, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(0, 1, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(0, 0, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(0, -1, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(1, 1, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(1, 0, 1), BuildingCategoryType.Tile, 15));
            placedObjectDatas.Add(new PlacedObjectData(new Vector3IntData(1, -1, 1), BuildingCategoryType.Tile, 15));


            for (int i = 0; i < placedObjectDatas.Count; ++i)
            {
                placedObjectDataRepositorys.SetPlacedObjectData(placedObjectDatas[i].PivotGridPosition, placedObjectDatas[i]);
            }
        }
    }
}