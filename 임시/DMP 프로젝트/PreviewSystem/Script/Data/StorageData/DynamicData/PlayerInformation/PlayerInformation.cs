namespace Data.Storage.Dynamic
{
    public class PlayerInformation
    {
        private UserInformation userInformation;
        private PlayerGameSetting playerGameSetting;

        private PlayerStructureInventoryDataNestedRepository playerStructureInventoryDataNestedRepository;
        private PlayerStructureModuleInventoryDataRepository playerStructureModuleInventoryDataRepository;
        private PlacedObjectDataRepository placedObjectDataRepository;


        public PlayerInformation()
        {
            this.userInformation = new UserInformation();
            this.playerGameSetting = new PlayerGameSetting();

            this.playerStructureInventoryDataNestedRepository = new PlayerStructureInventoryDataNestedRepository();
            this.playerStructureModuleInventoryDataRepository = new PlayerStructureModuleInventoryDataRepository();
            this.placedObjectDataRepository = new PlacedObjectDataRepository();
        }

        public UserInformation UserInformation { get => userInformation; }
        public PlayerGameSetting PlayerGameSetting { get => playerGameSetting; }

        // DMP
        public PlayerStructureInventoryDataNestedRepository PlayerStructureInventoryDataNestedRepository { get => playerStructureInventoryDataNestedRepository; }
        public PlayerStructureModuleInventoryDataRepository PlayerStructureModuleInventoryDataRepository { get => playerStructureModuleInventoryDataRepository; }
        public PlacedObjectDataRepository PlacedObjectDataRepository { get => placedObjectDataRepository; }
    }
}
