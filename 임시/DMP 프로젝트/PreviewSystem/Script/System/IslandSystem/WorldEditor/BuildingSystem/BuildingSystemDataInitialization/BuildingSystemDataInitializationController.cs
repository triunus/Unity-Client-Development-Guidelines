using UnityEngine;

using Data;
using Data.Temporay;

namespace System.BuildingSystem
{
    public class BuildingSystemDataInitializationModel
    {
        private BuildingSystemData buildingSystemData;

        public BuildingSystemDataInitializationModel()
        {
            this.buildingSystemData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.BuildingSystemData;
        }

        public void InitialSetting(BuildingCategoryType structureCategoryType, int structureNumber = 0)
        {
            this.buildingSystemData.IsBuildingSystemOperating = true;
            this.buildingSystemData.BuildingSystemOperationType = BuildingSystemOperationType.Non;

            this.buildingSystemData.StructureCategoryType = structureCategoryType;
            this.buildingSystemData.StructureNumber = structureNumber;

            // 공지
            this.buildingSystemData.IsBuildingSystemOperatingObserverSubject.NotifySubscribers();
            this.buildingSystemData.BuildSystemTypeObserverSubject.NotifySubscribers();
        }

        public void InitialSetting(CoordinatesData coordinatesData)
        {
            this.buildingSystemData.IsBuildingSystemOperating = true;

            if (coordinatesData.StructureCategoryType.Equals(BuildingCategoryType.Tile))
                this.buildingSystemData.BuildingSystemOperationType = BuildingSystemOperationType.TileDeletion;
            else
                this.buildingSystemData.BuildingSystemOperationType = BuildingSystemOperationType.StructureDeletion;

            this.buildingSystemData.StructureCategoryType = coordinatesData.StructureCategoryType;
            this.buildingSystemData.StructureNumber = coordinatesData.StructureNumber;
            this.buildingSystemData.GridPosition = coordinatesData.GirdPosition;
            this.buildingSystemData.StructureObjectRotationType = coordinatesData.StructureObjectRotationType;

            // 공지
            this.buildingSystemData.IsBuildingSystemOperatingObserverSubject.NotifySubscribers();
            this.buildingSystemData.BuildSystemTypeObserverSubject.NotifySubscribers();
        }

        public void Clear()
        {
            this.buildingSystemData.IsBuildingSystemOperating = false;
            this.buildingSystemData.IsBuildingSystemOperatingObserverSubject.NotifySubscribers();
        }
    }

    public class BuildingSystemDataInitializationController : MonoBehaviour
    {
        private BuildingSystemDataInitializationModel buildSystemDataInitializationModel;

        private void Awake()
        {
            this.buildSystemDataInitializationModel = new BuildingSystemDataInitializationModel();
        }

        public void InitialSetting(BuildingCategoryType structureCategoryType, int structureNumber = 0)
        {
            this.buildSystemDataInitializationModel.InitialSetting(structureCategoryType, structureNumber);
        }

        public void InitialSetting(CoordinatesData coordinatesData)
        {
            this.buildSystemDataInitializationModel.InitialSetting(coordinatesData);
        }

        public void Clear()
        {
            this.buildSystemDataInitializationModel.Clear();
        }
    }
}