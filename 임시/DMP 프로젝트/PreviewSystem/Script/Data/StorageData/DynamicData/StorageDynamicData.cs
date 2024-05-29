namespace Data.Storage.Dynamic
{
    public class StorageDynamicData
    {
        private static StorageDynamicData instance;

        private PlayerInformation playerInformation;

        public static StorageDynamicData Instance
        {
            get
            {
                if (StorageDynamicData.instance == null)
                {
                    StorageDynamicData.instance = new StorageDynamicData();
                    StorageDynamicData.instance.Init();
                }

                return StorageDynamicData.instance;
            }
        }

        private void Init()
        {
            if (this.playerInformation == null) this.playerInformation = new PlayerInformation();
        }

        public PlayerInformation PlayerInformation { get => playerInformation; set => playerInformation = value; }
    }
}