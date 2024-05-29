using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Storage.Static
{
    [Serializable]
    [CreateAssetMenu(fileName = "BuildingSystemStructureDataNestedGroup", menuName = "ScriptableObject/IslandScene/WorldEditor/BuildingSystem/BuildingSystemStructureDataNestedGroup")]
    public class BuildingSystemStructureDataNestedGroup : ScriptableObject
    {
        [SerializeField] private List<BuildingSystemStructureDataGroup> buildSystemStructureDataGroups;

        public List<BuildingSystemStructureDataGroup> BuildSystemStructureDataGroups { get => buildSystemStructureDataGroups; }
    }
}