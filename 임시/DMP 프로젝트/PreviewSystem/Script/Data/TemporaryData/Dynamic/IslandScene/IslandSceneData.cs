namespace Data.Temporay
{
    public class IslandSceneData
    {
        private WorldEditorData worldEditorData;


        private CoordinatesDataRepository coordinatesDataRepository;

        public IslandSceneData()
        {
            this.worldEditorData = new WorldEditorData();


            this.coordinatesDataRepository = new CoordinatesDataRepository();
        }

        public WorldEditorData WorldEditorData { get => worldEditorData; }


        public CoordinatesDataRepository CoordinatesDataRepository { get => coordinatesDataRepository; }
    }
}