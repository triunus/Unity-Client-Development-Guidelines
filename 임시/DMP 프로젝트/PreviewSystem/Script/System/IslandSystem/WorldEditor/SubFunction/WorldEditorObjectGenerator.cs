using UnityEngine;

using Data;
using Data.Storage.Static;

namespace System.BuildingSystem
{
    public class WorldEditorObjectGenerator : MonoBehaviour
    {
        private BuildSystemStructureDataGroupRepository buildSystemStructureDataGroupRepository;
        private BuildingSystemStructureFloorDataRepository buildSystemStructureFloorRepository;

        private void Awake()
        {
            this.buildSystemStructureDataGroupRepository = StorageStaticData.Instance.BuildSystemStructureDataGroupRepository;
            this.buildSystemStructureFloorRepository = StorageStaticData.Instance.BuildingSystemStructureFloorDataRepository;
        }

        public GameObject GenerateFloorIndicatorObject(SizeType sizeType)
        {
            GameObject prefab = this.buildSystemStructureFloorRepository.GetBuildSystemStructureFloorData(sizeType).FloorPrefab;

            return Instantiate(prefab);
        }

        public GameObject GenerateObject(BuildingCategoryType structureCategoryType, int structureNumber)
        {
//            Debug.Log($"structureCategoryType : {structureCategoryType}, structureNumber : {structureNumber}");

            GameObject prefab = this.buildSystemStructureDataGroupRepository.GetBuildSystemStructureData(structureCategoryType, structureNumber).StructurePrefab;

            return Instantiate(prefab);
        }

        public void DestroyObject(GameObject gameObject)
        {
            Destroy(gameObject);
        }
    }
}