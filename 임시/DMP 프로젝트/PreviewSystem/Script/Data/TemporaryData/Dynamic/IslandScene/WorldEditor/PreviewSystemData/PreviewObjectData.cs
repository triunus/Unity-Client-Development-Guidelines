using UnityEngine;

using DesignPattern.Observer;

namespace Data.Temporay
{
    // Observer�� ���� ������ Ŭ�����Դϴ�.
    public partial class PreviewSystemData
    {
        // ��ü�� ȸ���� ����, ��ü�� �����ϴ� GridPosition�� ���� ������ �� ����մϴ�.
        private StructureObjectRotationType structureObjectRotationType;

        // ��ü ��ġ�� �����ϴµ� ����ϴ� �������Դϴ�.
        private Vector3Int previewObjectGridPosition;
        private float floorCollisionPosition;
        // -----

        private bool worldEidtorObjectPlaceable;


        private IObserverSubject<StructureObjectRotationType> structureObjectRotationTypeObserverSubject;

        private IObserverSubject<Vector3Int> previewObjectGridPositionObserverSubject;
        private IObserverSubject<float> floorCollisionPositionObserverSubject;

        private IObserverSubject<bool> worldEidtorObjectPlaceableObserverSubject;

        public PreviewSystemData()
        {
            this.structureObjectRotationTypeObserverSubject = new ObserverSubject<StructureObjectRotationType>(ObserverType.StructureObjectRotationType, this.structureObjectRotationType);

            this.previewObjectGridPositionObserverSubject = new ObserverSubject<Vector3Int>(ObserverType.PreviewObjectGridPosition, this.previewObjectGridPosition);
            this.floorCollisionPositionObserverSubject = new ObserverSubject<float>(ObserverType.FloorCollisionPosition, this.floorCollisionPosition);

            this.worldEidtorObjectPlaceableObserverSubject = new ObserverSubject<bool>(ObserverType.WorldEidtorObjectPlaceable, this.worldEidtorObjectPlaceable);
        }

        public StructureObjectRotationType StructureObjectRotationType
        {
            get => structureObjectRotationType;
            set
            {
                this.structureObjectRotationType = value;
                this.structureObjectRotationTypeObserverSubject.UpdateObserverData(this.structureObjectRotationType);
            }
        }

        public Vector3Int PreviewObjectGridPosition
        {
            get => previewObjectGridPosition;
            set
            {
                this.previewObjectGridPosition = value;
                this.previewObjectGridPositionObserverSubject.UpdateObserverData(this.previewObjectGridPosition);
            }
        }
        public float FloorCollisionPosition
        {
            get => floorCollisionPosition;
            set
            {
                this.floorCollisionPosition = value;
                this.floorCollisionPositionObserverSubject.UpdateObserverData(this.floorCollisionPosition);
            }
        }

        /// <summary>
        /// 0 : �ش� ��ǥ ���Ұ��� or �ش� ��ǥ�� ��ġ �Ұ���.
        /// 1 : ��ġ�� �ǹ� ��� ����.
        /// 2 : ��ġ ����.
        /// </summary>
        public bool WorldEidtorObjectPlaceable
        {
            get => worldEidtorObjectPlaceable;
            set
            {
                this.worldEidtorObjectPlaceable = value;
                this.worldEidtorObjectPlaceableObserverSubject.UpdateObserverData(this.worldEidtorObjectPlaceable);
            }
        }

        public IObserverSubject<StructureObjectRotationType> StructureObjectRotationTypeObserverSubject { get => structureObjectRotationTypeObserverSubject; }

        public IObserverSubject<Vector3Int> PreviewObjectGridPositionObserverSubject { get => previewObjectGridPositionObserverSubject; }
        public IObserverSubject<float> FloorCollisionPositionObserverSubject { get => floorCollisionPositionObserverSubject; }

        public IObserverSubject<bool> WorldEidtorObjectPlaceableObserverSubject { get => worldEidtorObjectPlaceableObserverSubject; }
    }

    // ��ü�� �⺻ ������ ��� ���� �������Դϴ�.
    public partial class PreviewSystemData
    {
        private BuildingCategoryType buildingCategoryType;
        private int structureNumber;

        private Vector2Int size;

        private GameObject previewStructureObject;
        private GameObject previewFloorObject;

        private Material previewMaterialPrefab;
        private Material previewFoliageMaterialPrefab;


        public BuildingCategoryType BuildingCategoryType { get => buildingCategoryType; set => buildingCategoryType = value; }
        public int StructureNumber { get => structureNumber; set => structureNumber = value; }

        public Vector2Int Size { get => size; set => size = value; }

        public GameObject PreviewStructureObject { get => previewStructureObject; set => previewStructureObject = value; }
        public GameObject PreviewFloorObject { get => previewFloorObject; set => previewFloorObject = value; }
        public Material PreviewMaterialPrefab { get => previewMaterialPrefab; set => previewMaterialPrefab = value; }
        public Material PreviewFoliageMaterialPrefab { get => previewFoliageMaterialPrefab; set => previewFoliageMaterialPrefab = value; }
    }
}
