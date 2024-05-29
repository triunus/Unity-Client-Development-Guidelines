using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Storage.Static
{
    [Serializable]
    [CreateAssetMenu(fileName = "UIStructureDataGroup", menuName = "ScriptableObject/IslandScene/WorldEditor/UIStructureData/UIStructureDataGroup")]
    public class UIStructureDataGroup : ScriptableObject
    {
        [SerializeField] private BuildingCategoryType structureCategoryType;
        [SerializeField] private List<UIStructureData> UIStructureDatas_;

        public BuildingCategoryType StructureCategoryType { get => structureCategoryType; }
        public List<UIStructureData> UIStructureDatas { get => UIStructureDatas_; }
    }

    [Serializable]
    public class UIStructureData
    {
        [SerializeField] private BuildingCategoryType structureCategoryType;
        [SerializeField] private int structureNumber;
        [SerializeField] private Texture2D texture2D;

        public BuildingCategoryType StructureCategoryType { get => structureCategoryType; }
        public int StructureNumber { get => structureNumber; }
        public Texture2D Texture2D { get => texture2D; }
    }
}