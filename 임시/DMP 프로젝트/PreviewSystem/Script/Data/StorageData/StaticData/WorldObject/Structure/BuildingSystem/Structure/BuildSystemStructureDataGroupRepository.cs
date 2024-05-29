using System.Collections.Generic;
using UnityEngine;

namespace Data.Storage.Static
{
    public class BuildSystemStructureDataGroupRepository
    {
        private Dictionary<BuildingCategoryType, BuildingSystemStructureDataGroup> buildSystemStructureDataGroups;

        public BuildSystemStructureDataGroupRepository()
        {
            this.buildSystemStructureDataGroups = new Dictionary<BuildingCategoryType, BuildingSystemStructureDataGroup>();

            this.SetBuildSystemStructureDataGroupRepository();
        }
        private void SetBuildSystemStructureDataGroupRepository()
        {
            BuildingSystemStructureDataNestedGroup buildingSystemStructureDataNestedGroup =
                 Resources.Load<BuildingSystemStructureDataNestedGroup>("ScriptableObject/IslandScene/WorldEditor/BuildingSystem/BuildingSystemStructureDataNestedGroup");

            for (int i = 0; i < buildingSystemStructureDataNestedGroup.BuildSystemStructureDataGroups.Count; ++i)
            {
                this.SetBuildSystemStructureDataGroup(buildingSystemStructureDataNestedGroup.BuildSystemStructureDataGroups[i]);
            }
        }
        private void SetBuildSystemStructureDataGroup(BuildingSystemStructureDataGroup buildSystemStructureDataGroup)
        {
            if (this.buildSystemStructureDataGroups.ContainsKey(buildSystemStructureDataGroup.StructureCategoryType))
                return;
            else
                this.buildSystemStructureDataGroups.Add(buildSystemStructureDataGroup.StructureCategoryType, buildSystemStructureDataGroup);
        }

        public BuildingSystemStructureDataGroup GetBuildSystemStructureDataGroup(BuildingCategoryType structureCategoryType)
        {
            if (this.buildSystemStructureDataGroups.ContainsKey(structureCategoryType))
                return this.buildSystemStructureDataGroups[structureCategoryType];
            else
                return null;
        }
        public BuildingSystemStructureData GetBuildSystemStructureData(BuildingCategoryType structureCategoryType, int structureNumber)
        {
            if (this.buildSystemStructureDataGroups.ContainsKey(structureCategoryType))
                return this.buildSystemStructureDataGroups[structureCategoryType].GetBuildSystemStructureData(structureNumber);
            else
                return null;
        }
    }
}