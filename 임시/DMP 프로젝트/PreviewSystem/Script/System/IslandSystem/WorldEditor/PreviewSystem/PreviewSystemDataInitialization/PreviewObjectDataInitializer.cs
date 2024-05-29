using UnityEngine;

using Data;
using Data.Temporay;
using Data.Storage.Static;

namespace System.BuildingSystem
{
    /// <summary>
    /// BuildingSystem에서 공통으로 사용할 Data를 관리합니다.
    /// 최초 Set, 최후 Clear 등을 수행합니다.
    /// </summary>
    public class PreviewObjectDataInitializer
    {
        // 저장 불변 데이터
        private BuildSystemStructureDataGroupRepository buildSystemStructureDataGroupResolver;
        private BuildingSystemStructureFloorDataRepository buildSystemStructureFloorResolver;        

        // StructurePreviewData를 구성할 객체에 대한 정보 (size와 prefab)
        private PreviewSystemData previewObjectData;
        private Transform previewParentGameObject;

        public PreviewObjectDataInitializer(PreviewSystemData previewObjectData, Transform previewParentGameObject)
        {
            this.buildSystemStructureDataGroupResolver = StorageStaticData.Instance.BuildSystemStructureDataGroupRepository;
            this.buildSystemStructureFloorResolver = StorageStaticData.Instance.BuildingSystemStructureFloorDataRepository;

            this.previewParentGameObject = previewParentGameObject;
            this.previewObjectData = previewObjectData;
        }

        // 설정.
        public void InitialSetting()
        {
            // 임시 동적 데이터
            BuildingSystemData buildingSystemData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.BuildingSystemData;

            BuildingSystemStructureData buildSystemStructureData
                = this.buildSystemStructureDataGroupResolver.GetBuildSystemStructureData(buildingSystemData.StructureCategoryType, buildingSystemData.StructureNumber);
            BuildingSystemStructureFloorData buildSystemStructureFloorData
                = this.buildSystemStructureFloorResolver.GetBuildSystemStructureFloorData(buildSystemStructureData.SizeType);

            this.previewObjectData.BuildingCategoryType = buildingSystemData.StructureCategoryType;
            this.previewObjectData.StructureNumber = buildingSystemData.StructureNumber;

            this.previewObjectData.Size = this.ConvertSize(buildSystemStructureData.SizeType);
            this.previewObjectData.StructureObjectRotationType = buildingSystemData.StructureObjectRotationType;

            this.previewObjectData.PreviewStructureObject = Util.GameObjectGenerator.GenerateGameObject(buildSystemStructureData.StructurePrefab);
            this.previewObjectData.PreviewFloorObject = Util.GameObjectGenerator.GenerateGameObject(buildSystemStructureFloorData.FloorPrefab);

            this.previewObjectData.PreviewStructureObject.transform.SetParent(previewParentGameObject);
            this.previewObjectData.PreviewFloorObject.transform.SetParent(previewParentGameObject);

            this.SetPreviewPrefabMaterial();
        }


        private Vector2Int ConvertSize(SizeType sizeType)
        {
            int sizeValue = (int)sizeType;

            int quotient = sizeValue / 16;
            int remainder = sizeValue % 16;

            return new Vector2Int(this.IntToSize(quotient), this.IntToSize(remainder));
        }
        private int IntToSize(int value)
        {
            int result = 0;

            switch (value)
            {
                case 1:
                    result = 1;
                    break;
                case 2:
                    result = 2;
                    break;
                case 4:
                    result = 3;
                    break;
                case 8:
                    result = 4;
                    break;
                default:
                    break;
            }

            return result;
        }


        /// <summary>
        /// 매개변수로 받은 GameObject의 모든 materials을 정해진 Material로 변경합니다.
        /// </summary>
        private void SetPreviewPrefabMaterial()
        {
            Renderer[] renderers = this.previewObjectData.PreviewStructureObject.GetComponentsInChildren<Renderer>();

            foreach (Renderer renderer in renderers)
            {
                Material[] materials = renderer.materials;

                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i].shader.name.Equals("Quibli/Foliage"))
                    {
                        if(this.previewObjectData.PreviewFoliageMaterialPrefab == null)
                        {
                            this.previewObjectData.PreviewFoliageMaterialPrefab = materials[i];
                        }

                        materials[i] = this.previewObjectData.PreviewFoliageMaterialPrefab;
                    }
                    else
                    {
                        if (this.previewObjectData.PreviewMaterialPrefab == null)
                        {
                            this.previewObjectData.PreviewMaterialPrefab = materials[i];
                        }

                        materials[i] = this.previewObjectData.PreviewMaterialPrefab;
                    }
                }
                renderer.materials = materials;
            }
        }

        // 해제.
        public void Clear()
        {
            Util.GameObjectGenerator.Destroy(this.previewObjectData.PreviewStructureObject);
            Util.GameObjectGenerator.Destroy(this.previewObjectData.PreviewFloorObject);

            this.previewObjectData.PreviewMaterialPrefab = null;
            this.previewObjectData.PreviewFoliageMaterialPrefab = null;
        }        
    }
}