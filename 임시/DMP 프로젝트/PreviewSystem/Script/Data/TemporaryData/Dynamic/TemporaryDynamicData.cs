namespace Data.Temporay
{
    public class TemporaryDynamicData
    {
        private static TemporaryDynamicData instance;

        private IslandSceneData islandSceneData;

        public static TemporaryDynamicData Instance
        {
            get
            {
                if (TemporaryDynamicData.instance == null)
                {
                    TemporaryDynamicData.instance = new TemporaryDynamicData();
                    TemporaryDynamicData.instance.Init();
                }

                return TemporaryDynamicData.instance;
            }
        }

        private void Init()
        {
            if (this.islandSceneData == null) this.islandSceneData = new IslandSceneData();
        }

        public IslandSceneData IslandSceneData { get => islandSceneData; }
    }
}