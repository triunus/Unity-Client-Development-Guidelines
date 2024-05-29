using UnityEngine;

using DesignPattern.Observer;

namespace Data.Temporay
{
    public partial class BuildingSystemData
    {
        private bool isBuildingSystemOperating;
        private IObserverSubject<bool> isBuildingSystemOperatingObserverSubject;

        private BuildingSystemOperationType buildingSystemOperationType;
        private IObserverSubject<BuildingSystemOperationType> buildingSystemOperationTypeObserverSubject;

        public BuildingSystemData()
        {
            this.isBuildingSystemOperating = false;

            this.isBuildingSystemOperatingObserverSubject =
                new ObserverSubject<bool>(ObserverType.IsBuildingSystemOperating, this.isBuildingSystemOperating);

            this.buildingSystemOperationType = BuildingSystemOperationType.Non;

            this.buildingSystemOperationTypeObserverSubject =
                new ObserverSubject<BuildingSystemOperationType>(ObserverType.BuildingSystemOperationType, this.buildingSystemOperationType);
        }

        public bool IsBuildingSystemOperating
        {
            get => isBuildingSystemOperating;
            set
            {
                this.isBuildingSystemOperating = value;
                this.isBuildingSystemOperatingObserverSubject.UpdateObserverData(this.isBuildingSystemOperating);
            }
        }
        public IObserverSubject<bool> IsBuildingSystemOperatingObserverSubject { get => isBuildingSystemOperatingObserverSubject; }

        public BuildingSystemOperationType BuildingSystemOperationType
        {
            get => buildingSystemOperationType;
            set
            {
                this.buildingSystemOperationType = value;
                this.buildingSystemOperationTypeObserverSubject.UpdateObserverData(this.buildingSystemOperationType);
            }
        }
        public IObserverSubject<BuildingSystemOperationType> BuildSystemTypeObserverSubject { get => buildingSystemOperationTypeObserverSubject; }

    }

    public partial class BuildingSystemData
    {
        private BuildingCategoryType structureCategoryType;
        private int structureNumber;

        private Vector3Int gridPosition;
        private StructureObjectRotationType structureObjectRotationType;

        public BuildingCategoryType StructureCategoryType { get => structureCategoryType; set => structureCategoryType = value; }
        public int StructureNumber { get => structureNumber; set => structureNumber = value; }

        public Vector3Int GridPosition { get => gridPosition; set => gridPosition = value; }
        public StructureObjectRotationType StructureObjectRotationType { get => structureObjectRotationType; set => structureObjectRotationType = value; }
    }
}

namespace Data
{
    public enum BuildingSystemOperationType
    {
        Non,
        TilePlacement,
        TileDeletion,
        StructurePlacement,
        StructureDeletion
    }
}