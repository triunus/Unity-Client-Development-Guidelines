using UnityEngine;

using Data;
using Data.Temporay;
using Data.Storage.Static;

namespace System.BuildingSystem
{
    /// <summary>
    /// BuildingSystem���� �������� ����� Data�� �����մϴ�.
    /// ���� Set, ���� Clear ���� �����մϴ�.
    /// </summary>
    public class PreviewObjectDataInitializer
    {
        // ���� �Һ� ������
        private BuildSystemStructureDataGroupRepository buildSystemStructureDataGroupResolver;
        private BuildingSystemStructureFloorDataRepository buildSystemStructureFloorResolver;        

        // StructurePreviewData�� ������ ��ü�� ���� ���� (size�� prefab)
        private PreviewSystemData previewObjectData;
        private Transform previewParentGameObject;

        public PreviewObjectDataInitializer(PreviewSystemData previewObjectData, Transform previewParentGameObject)
        {
            this.buildSystemStructureDataGroupResolver = StorageStaticData.Instance.BuildSystemStructureDataGroupRepository;
            this.buildSystemStructureFloorResolver = StorageStaticData.Instance.BuildingSystemStructureFloorDataRepository;

            this.previewParentGameObject = previewParentGameObject;
            this.previewObjectData = previewObjectData;
        }

        // ����.
        public void InitialSetting()
        {
            // �ӽ� ���� ������
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
        /// �Ű������� ���� GameObject�� ��� materials�� ������ Material�� �����մϴ�.
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

        // ����.
        public void Clear()
        {
            Util.GameObjectGenerator.Destroy(this.previewObjectData.PreviewStructureObject);
            Util.GameObjectGenerator.Destroy(this.previewObjectData.PreviewFloorObject);

            this.previewObjectData.PreviewMaterialPrefab = null;
            this.previewObjectData.PreviewFoliageMaterialPrefab = null;
        }        
    }
}