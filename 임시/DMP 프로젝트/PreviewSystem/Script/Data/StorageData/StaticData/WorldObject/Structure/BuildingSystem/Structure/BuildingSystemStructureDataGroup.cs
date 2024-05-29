using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Storage.Static
{
    [Serializable]
    [CreateAssetMenu(fileName = "BuildingSystemStructureDataGroup", menuName = "ScriptableObject/IslandScene/WorldEditor/BuildingSystem/BuildingSystemStructureDataGroup")]
    public class BuildingSystemStructureDataGroup : ScriptableObject
    {
        [SerializeField] private BuildingCategoryType structureCategoryType;
        [SerializeField] private List<BuildingSystemStructureData> buildingSystemStructureDatas;

        public BuildingSystemStructureData GetBuildSystemStructureData(int structureNumber)
        {
            BuildingSystemStructureData tempBuildSystemStructureData = null;

            for (int i = 0; i < this.buildingSystemStructureDatas.Count; ++i)
            {
                if (this.buildingSystemStructureDatas[i].StructureNumber == structureNumber)
                    tempBuildSystemStructureData = this.buildingSystemStructureDatas[i];
            }

            return tempBuildSystemStructureData;
        }

        public BuildingCategoryType StructureCategoryType { get => structureCategoryType; }
        public List<BuildingSystemStructureData> BuildingSystemStructureDatas { get => buildingSystemStructureDatas; }
    }

    [Serializable]
    public class BuildingSystemStructureData
    {
        [SerializeField] private BuildingCategoryType structureCategoryType;
        [SerializeField] private int structureNumber;

        [SerializeField] private SizeType sizeType;
        [SerializeField] private GameObject structurePrefab;

        public BuildingCategoryType StructureCategoryType { get => structureCategoryType; }
        public int StructureNumber { get => structureNumber; }
        public SizeType SizeType { get => sizeType; }
        public GameObject StructurePrefab { get => structurePrefab; }
    }
}