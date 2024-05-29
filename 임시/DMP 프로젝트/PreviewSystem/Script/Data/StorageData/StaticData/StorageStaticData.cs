namespace Data.Storage.Static
{
    public class StorageStaticData
    {
        private static StorageStaticData instance;

        private UIStructureDataGroupRepository UIStructureDataGroupRepository_;
        private BuildSystemStructureDataGroupRepository buildSystemStructureDataGroupRepository;
        private BuildingSystemStructureFloorDataRepository buildingSystemStructureFloorDataRepository;

        public static StorageStaticData Instance
        {
            get
            {
                if (StorageStaticData.instance == null)
                {
                    StorageStaticData.instance = new StorageStaticData();
                    StorageStaticData.instance.Init();
                }

                return StorageStaticData.instance;
            }
        }

        private void Init()
        {
            if (this.UIStructureDataGroupRepository_ == null) this.UIStructureDataGroupRepository_ = new UIStructureDataGroupRepository();
            if (this.buildSystemStructureDataGroupRepository == null) this.buildSystemStructureDataGroupRepository = new BuildSystemStructureDataGroupRepository();
            if (this.buildingSystemStructureFloorDataRepository == null) this.buildingSystemStructureFloorDataRepository = new BuildingSystemStructureFloorDataRepository();
        }

        public UIStructureDataGroupRepository UIStructureDataGroupRepository { get => UIStructureDataGroupRepository_; }
        public BuildSystemStructureDataGroupRepository BuildSystemStructureDataGroupRepository { get => buildSystemStructureDataGroupRepository; }
        public BuildingSystemStructureFloorDataRepository BuildingSystemStructureFloorDataRepository { get => buildingSystemStructureFloorDataRepository; }
    }
}