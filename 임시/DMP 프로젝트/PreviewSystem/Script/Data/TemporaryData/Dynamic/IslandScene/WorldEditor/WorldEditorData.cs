namespace Data.Temporay
{
    public class WorldEditorData
    {
        private BuildingSystemData buildingSystemData;
        private PreviewSystemData previewObjectData;

        public WorldEditorData()
        {
            this.buildingSystemData = new BuildingSystemData();
            this.previewObjectData = new PreviewSystemData();
        }

        public BuildingSystemData BuildingSystemData { get => buildingSystemData; }
        public PreviewSystemData PreviewSystemData { get => previewObjectData; }
    }
}