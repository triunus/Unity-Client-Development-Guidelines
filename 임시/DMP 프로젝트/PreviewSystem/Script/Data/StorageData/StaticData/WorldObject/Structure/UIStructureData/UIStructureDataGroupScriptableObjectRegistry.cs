using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Storage.Static
{
    [Serializable]
    [CreateAssetMenu(fileName = "UIStructureDataGroupScriptableObjectRegistry", menuName = "ScriptableObject/IslandScene/WorldEditor/UIStructureData/UIStructureDataGroupScriptableObjectRegistry")]
    public class UIStructureDataGroupScriptableObjectRegistry : ScriptableObject
    {
        [UnityEngine.SerializeField]
        private List<UIStructureDataGroup> UIStructureDataGroup_;

        public List<UIStructureDataGroup> UIStructureDataGroup { get => UIStructureDataGroup_; }
    }
}