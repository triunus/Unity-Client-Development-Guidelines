using System.Collections.Generic;
using UnityEngine;

using Data.Storage.Dynamic;

namespace Data.Temporay
{
    public class CoordinatesDataRepository
    {
        private Dictionary<Vector3Int, CoordinatesData> coordinatesDataRepositorys;

        public CoordinatesDataRepository()
        {
            this.coordinatesDataRepositorys = new Dictionary<Vector3Int, CoordinatesData>();
        }

        public void SetCoordinatesData(Vector3Int gridPosition, CoordinatesData coordinatesData)
        {
            if (this.coordinatesDataRepositorys.ContainsKey(gridPosition))
                this.coordinatesDataRepositorys[gridPosition] = coordinatesData;
            else
                this.coordinatesDataRepositorys.Add(gridPosition, coordinatesData);
        }

        public CoordinatesData GetCoordinatesData(Vector3Int gridPosition)
        {
            if (this.coordinatesDataRepositorys.ContainsKey(gridPosition))
                return this.coordinatesDataRepositorys[gridPosition];
            else
                return null;
        }

        public bool IsKeyContain(Vector3Int gridPosition)
        {
            if (this.coordinatesDataRepositorys.ContainsKey(gridPosition)) return true;
            else return false;
        }

        public bool IsKeyContainTileStructureCategory(Vector3Int gridPosition)
        {
            if (this.coordinatesDataRepositorys.ContainsKey(gridPosition) &&
                this.coordinatesDataRepositorys[gridPosition].StructureCategoryType.Equals(BuildingCategoryType.Tile)) return true;
            else return false;
        }
    }

    public class CoordinatesData
    {
        private Vector3Int gridPosition;

        private BuildingCategoryType structureCategoryType;
        private int structureNumber;

        private StructureObjectRotationType structureObjectRotationType;
        private GameObject gameObject;

        public CoordinatesData(Vector3Int gridPosition, BuildingCategoryType structureCategoryType, int structureNumber, StructureObjectRotationType structureObjectRotationType, GameObject gameObject)
        {
            this.gridPosition = gridPosition;
            this.structureCategoryType = structureCategoryType;
            this.structureNumber = structureNumber;
            this.structureObjectRotationType = structureObjectRotationType;
            this.gameObject = gameObject;
        }

        public CoordinatesData(Vector3IntData gridPosition, BuildingCategoryType structureCategoryType, int structureNumber, StructureObjectRotationType structureObjectRotationType, GameObject gameObject)
        {
            this.gridPosition = new Vector3Int(gridPosition.X, gridPosition.Y, gridPosition.Z);
            this.structureCategoryType = structureCategoryType;
            this.structureNumber = structureNumber;
            this.structureObjectRotationType = structureObjectRotationType;
            this.gameObject = gameObject;
        }

        public Vector3Int GirdPosition { get => gridPosition; set => gridPosition = value; }

        public BuildingCategoryType StructureCategoryType { get => structureCategoryType; set => structureCategoryType = value; }
        public int StructureNumber { get => structureNumber; set => structureNumber = value; }

        public StructureObjectRotationType StructureObjectRotationType { get => structureObjectRotationType; set => structureObjectRotationType = value; }
        public GameObject GameObject { get => gameObject; set => gameObject = value; }
    }
}