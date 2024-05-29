using System.Collections.Generic;
using System;

using Data.Temporay;

namespace Data.Storage.Dynamic
{
    [Serializable]
    public class PlacedObjectDataRepository : IServerDataJsonConverter
    {
        private ServerDataType serverDataType;

        private Dictionary<Vector3IntData, PlacedObjectData> placedObjectDataRepositorys;

        public PlacedObjectDataRepository()
        {
            this.serverDataType = ServerDataType.PlacedObjectDataRepository;
            this.placedObjectDataRepositorys = new Dictionary<Vector3IntData, PlacedObjectData>();
        }

        public void SetPlacedObjectData(Vector3IntData vector3IntData, BuildingCategoryType structureCategoryType, int structureNumber)
        {
            PlacedObjectData newPlacedObjectData = new PlacedObjectData(vector3IntData, structureCategoryType, structureNumber);

            this.SetPlacedObjectData(vector3IntData, newPlacedObjectData);
        }
        public void SetPlacedObjectData(Vector3IntData vector3IntData, PlacedObjectData placedObjectData)
        {
            if (this.placedObjectDataRepositorys.ContainsKey(vector3IntData))
                this.placedObjectDataRepositorys[vector3IntData] = placedObjectData;
            else
                this.placedObjectDataRepositorys.Add(vector3IntData, placedObjectData);
        }

        public PlacedObjectData GetPlacedObjectData(Vector3IntData vector3IntData)
        {
            if (this.placedObjectDataRepositorys.ContainsKey(vector3IntData))
                return this.placedObjectDataRepositorys[vector3IntData];
            else
                return null;
        }

        public void ClearKeyAndValue(Vector3IntData vector3IntData)
        {
            if (!this.placedObjectDataRepositorys.ContainsKey(vector3IntData)) return;

            this.placedObjectDataRepositorys[vector3IntData] = null;
            this.placedObjectDataRepositorys.Remove(vector3IntData);
        }

        public Dictionary<Vector3IntData, PlacedObjectData>.Enumerator GetEnumerator()
        {
            return this.placedObjectDataRepositorys.GetEnumerator();
        }

        public string DataToJson()
        {
            throw new NotImplementedException();
        }

        public void JsonToData(string jsonString)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class PlacedObjectData
    {
        private Vector3IntData pivotGridPosition;

        private BuildingCategoryType buildingCategoryType;
        private int structureNumber;

        private StructureObjectRotationType structureObjectRotationType;

        public PlacedObjectData(Vector3IntData pivotGridPosition, BuildingCategoryType buildingCategoryType, int structureNumber,
                                    StructureObjectRotationType structureObjectRotationType = StructureObjectRotationType.Origin)
        {
            this.pivotGridPosition = pivotGridPosition;

            this.buildingCategoryType = buildingCategoryType;
            this.structureNumber = structureNumber;
            this.structureObjectRotationType = structureObjectRotationType;
        }

        public Vector3IntData PivotGridPosition { get => pivotGridPosition; set => pivotGridPosition = value; }

        public BuildingCategoryType BuildingCategoryType { get => buildingCategoryType; set => buildingCategoryType = value; }
        public int StructureNumber { get => structureNumber; set => structureNumber = value; }
        public StructureObjectRotationType StructureObjectRotationType { get => structureObjectRotationType; set => structureObjectRotationType = value; }
    }

    [Serializable]
    public struct Vector3IntData
    {
        private int x;
        private int y;
        private int z;

        public Vector3IntData(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3IntData(UnityEngine.Vector3Int vector3Int)
        {
            this.x = vector3Int.x;
            this.y = vector3Int.y;
            this.z = vector3Int.z;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Z { get => z; set => z = value; }
    }
}