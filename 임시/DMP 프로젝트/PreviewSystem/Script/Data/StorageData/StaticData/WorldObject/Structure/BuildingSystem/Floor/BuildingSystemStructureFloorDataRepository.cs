using System.Collections.Generic;

namespace Data.Storage.Static
{
    public class BuildingSystemStructureFloorDataRepository
    {
        private Dictionary<SizeType, BuildingSystemStructureFloorData> buildingSystemStructureFloorDatas;

        public BuildingSystemStructureFloorDataRepository()
        {
            this.buildingSystemStructureFloorDatas = new Dictionary<SizeType, BuildingSystemStructureFloorData>();

            this.SetBuildingSystemStructureFloorDataRepository();
        }
        private void SetBuildingSystemStructureFloorDataRepository()
        {
            BuildingSystemStructureFloorDataGroup buildSystemStructureFloorDataGroup =
                 UnityEngine.Resources.Load<BuildingSystemStructureFloorDataGroup>("ScriptableObject/IslandScene/WorldEditor/BuildingSystem/BuildingSystemStructureFloorDataGroup"); ;

            for (int i = 0; i < buildSystemStructureFloorDataGroup.BuildingSystemStructureFloorData.Count; ++i)
            {
                this.SetBuildSystemStructureFloorData(buildSystemStructureFloorDataGroup.BuildingSystemStructureFloorData[i]);
            }
        }
        private void SetBuildSystemStructureFloorData(BuildingSystemStructureFloorData buildSystemStructureFloorData)
        {
            if (this.buildingSystemStructureFloorDatas.ContainsKey(buildSystemStructureFloorData.SizeType))
                return;
            else
                this.buildingSystemStructureFloorDatas.Add(buildSystemStructureFloorData.SizeType, buildSystemStructureFloorData);
        }

        public BuildingSystemStructureFloorData GetBuildSystemStructureFloorData(SizeType sizeType)
        {
            if (this.buildingSystemStructureFloorDatas.ContainsKey(sizeType))
                return this.buildingSystemStructureFloorDatas[sizeType];
            else
                return null;
        }
    }
}
