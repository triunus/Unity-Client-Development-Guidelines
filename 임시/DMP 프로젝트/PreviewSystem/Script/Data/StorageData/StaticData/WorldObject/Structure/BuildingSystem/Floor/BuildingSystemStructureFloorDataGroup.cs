using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Storage.Static
{
    [Serializable]
    [CreateAssetMenu(fileName = "BuildingSystemStructureFloorDataGroup", menuName = "ScriptableObject/IslandScene/WorldEditor/BuildingSystem/BuildingSystemStructureFloorDataGroup")]
    public class BuildingSystemStructureFloorDataGroup : ScriptableObject
    {
        [SerializeField] private List<BuildingSystemStructureFloorData> buildingSystemStructureFloorData;

        public List<BuildingSystemStructureFloorData> BuildingSystemStructureFloorData { get => buildingSystemStructureFloorData; }
    }

    [Serializable]
    public class BuildingSystemStructureFloorData
    {
        [SerializeField] private SizeType sizeType;
        [SerializeField] private GameObject floorPrefab;

        public SizeType SizeType { get => sizeType; }
        public GameObject FloorPrefab { get => floorPrefab; }
    }
}