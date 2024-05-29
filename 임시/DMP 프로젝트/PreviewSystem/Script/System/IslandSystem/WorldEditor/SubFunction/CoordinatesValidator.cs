using System.Collections.Generic;
using UnityEngine;

using Data.Temporay;
using Data;

namespace System.BuildingSystem
{
    public class CoordinatesValidator
    {
        private CoordinatesDataRepository coordinatesDataRepository;

        public CoordinatesValidator()
        {
            this.coordinatesDataRepository = TemporaryDynamicData.Instance.IslandSceneData.CoordinatesDataRepository;
        }

        public bool IsAvailableCoordinates(Vector3Int objectPivotPosition, StructureObjectRotationType structureRotationType, Vector2Int objectSize)
        {
            List<Vector3Int> occupiedCoordinates = this.GetOccupiedCoordinates(objectPivotPosition, structureRotationType, objectSize);

            bool isAvailableForPlace = this.IsAvailableForPlace(occupiedCoordinates);

            return isAvailableForPlace;
        }
        public bool IsPlaceableObject(BuildingCategoryType structureCategoryType, Vector3Int objectPivotPosition, StructureObjectRotationType structureRotationType, Vector2Int objectSize)
        {
            if (structureCategoryType.Equals(BuildingCategoryType.Tile)) return true;

            Vector3Int underPosition = objectPivotPosition + Vector3Int.back;
            List<Vector3Int> occupiedCoordinates = this.GetOccupiedCoordinates(underPosition, structureRotationType, objectSize);

            bool isPlaceableObject = this.IsAvailableForPlaceByUnderObject(occupiedCoordinates);

            return isPlaceableObject;
        }




        private List<Vector3Int> GetOccupiedCoordinates(Vector3Int objectPivotPosition, StructureObjectRotationType structureRotationType, Vector2Int objectSize)
        {
            Vector2Int addedSize = objectSize - Vector2Int.one;

            List<Vector3Int> tempoccupiedCoordinates = new List<Vector3Int>();

            for (int horizontal = 0; horizontal <= addedSize.x; ++horizontal)
            {
                for(int vertical = 0; vertical <= addedSize.y; ++vertical)
                {
                    switch (structureRotationType)
                    {
                        case StructureObjectRotationType.Origin:
                            tempoccupiedCoordinates.Add(objectPivotPosition + new Vector3Int(horizontal, vertical, 0));
                            break;
                        case StructureObjectRotationType.OneQuarter:
                        case StructureObjectRotationType.TwoQuarter:
                            break;
                        case StructureObjectRotationType.ThreeQuarter:
                            tempoccupiedCoordinates.Add(objectPivotPosition + new Vector3Int(-vertical, horizontal, 0));
                            break;
                    }
                }
            }

            Debug.Log($"objectPivotPosition : {objectPivotPosition}");

            for(int i = 0; i < tempoccupiedCoordinates.Count; ++i)
            {
                Debug.Log($"tempoccupiedCoordinates : {tempoccupiedCoordinates[i]}");
            }

            return tempoccupiedCoordinates;
        }
        private bool IsAvailableForPlace(List<Vector3Int> occupiedCoordinates)
        {
            bool isAvailable = true;

            foreach(Vector3Int vector3IntData in occupiedCoordinates)
            {
                if (this.coordinatesDataRepository.IsKeyContain(vector3IntData))
                {
                    isAvailable = false;
                    break;
                }
            }

            return isAvailable;
        }
        private bool IsAvailableForPlaceByUnderObject(List<Vector3Int> occupiedCoordinates)
        {
            bool isAvailable = true;

            foreach (Vector3Int vector3Int in occupiedCoordinates)
            {
                CoordinatesData coordinatesData = this.coordinatesDataRepository.GetCoordinatesData(vector3Int);

                if (coordinatesData == null || !coordinatesData.StructureCategoryType.Equals(BuildingCategoryType.Tile))
                {
                    isAvailable = false;
                    break;
                }
            }

            return isAvailable;
        }
    }
}