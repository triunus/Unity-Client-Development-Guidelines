using System.Collections.Generic;
using UnityEngine;

namespace Data.Storage.Static
{
    public class UIStructureDataGroupRepository
    { 
        private Dictionary<BuildingCategoryType, UIStructureDataGroup> UIStructureDataGroups;

        // 생성자에서, Resources 폴더에서 STO를 가져와 초기화 수행.
        public UIStructureDataGroupRepository()
        {
            this.UIStructureDataGroups = new Dictionary<BuildingCategoryType, UIStructureDataGroup>();

            this.SetStructureCategoryType_UIStructureDataGroup();
        }
        private void SetStructureCategoryType_UIStructureDataGroup()
        {
            UIStructureDataGroupScriptableObjectRegistry structureDataGroupScriptableObjectRegistry =
                 Resources.Load<UIStructureDataGroupScriptableObjectRegistry>("ScriptableObject/IslandScene/WorldEditor/UIStructureData/UIStructureDataGroupScriptableObjectRegistry"); ;

            for (int i =0; i < structureDataGroupScriptableObjectRegistry.UIStructureDataGroup.Count; ++i)
            {
                this.SetUIStructureDataGroup(structureDataGroupScriptableObjectRegistry.UIStructureDataGroup[i]);
            }
        }
        private void SetUIStructureDataGroup(UIStructureDataGroup UIStructureDataGroup_)
        {
            if (this.UIStructureDataGroups.ContainsKey(UIStructureDataGroup_.StructureCategoryType))
                return;
            else
                this.UIStructureDataGroups.Add(UIStructureDataGroup_.StructureCategoryType, UIStructureDataGroup_);
        }

        public UIStructureDataGroup GetUIStructureDataGroup(BuildingCategoryType structureCategoryType)
        {
            if (this.UIStructureDataGroups.ContainsKey(structureCategoryType))
                return this.UIStructureDataGroups[structureCategoryType];
            else
                return null;
        }

        public Dictionary<BuildingCategoryType, UIStructureDataGroup>.Enumerator GetEnumerator()
        {
            return this.UIStructureDataGroups.GetEnumerator();
        }
    }
}