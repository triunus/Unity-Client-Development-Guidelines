using System.Collections.Generic;

using Data;
using Data.Storage.Dynamic;
using Data.Temporay;

using UnityEngine;
using System.BuildingSystem;

namespace System.Initialization
{
    public class IslandSceneInitializationModel
    {
        private ObjectStaticPositioner objectStaticPositioner;
        private WorldEditorObjectGenerator worldEditorObjectGenerator;

        private Transform parentGameObject;

        public IslandSceneInitializationModel(ObjectStaticPositioner objectStaticPositioner, WorldEditorObjectGenerator worldEditorObjectGenerator, Transform parentGameObject)
        {
            this.objectStaticPositioner = objectStaticPositioner;
            this.worldEditorObjectGenerator = worldEditorObjectGenerator;

            this.parentGameObject = parentGameObject;
        }

        // 유저의 저장 정보를 통해, 과거에 배치한 위치에 객체들을 배치한다.
        // 또한 임시 동적 데이터에 관련 데이터를 추가한다.

        public void SettingBuildingSystem()
        {
            PlacedObjectDataRepository placedObjectDataRepositorys = StorageDynamicData.Instance.PlayerInformation.PlacedObjectDataRepository;
            CoordinatesDataRepository coordinatesDataRepository = TemporaryDynamicData.Instance.IslandSceneData.CoordinatesDataRepository;

            var grid_PlacedObjectData = placedObjectDataRepositorys.GetEnumerator();

            while (grid_PlacedObjectData.MoveNext())
            {
                var currentPlacedObjectData = grid_PlacedObjectData.Current;
                GameObject newGameObject = this.worldEditorObjectGenerator.GenerateObject(currentPlacedObjectData.Value.BuildingCategoryType, currentPlacedObjectData.Value.StructureNumber);
                this.objectStaticPositioner.PositionObjectToWorldPosition(newGameObject, currentPlacedObjectData.Key);

                CoordinatesData coordinatesData = new CoordinatesData(currentPlacedObjectData.Key, currentPlacedObjectData.Value.BuildingCategoryType, currentPlacedObjectData.Value.StructureNumber, currentPlacedObjectData.Value.StructureObjectRotationType, newGameObject);
                coordinatesDataRepository.SetCoordinatesData(coordinatesData.GirdPosition, coordinatesData);

                newGameObject.transform.SetParent(this.parentGameObject);
            }
        }
    }


    public class IslandSceneInitializationController : MonoBehaviour
    {
        private PlayerInformationInitializationControllerModel playerInformationInitializationControllerModel;
        private IslandSceneInitializationModel islandSceneInitializationModel;

        [SerializeField] private ObjectStaticPositioner objectStaticPositioner;
        [SerializeField] private WorldEditorObjectGenerator worldEditorObjectGenerator;

        [SerializeField] private Transform parentGameObject;

        private void Awake()
        {
            this.playerInformationInitializationControllerModel = new PlayerInformationInitializationControllerModel();

            this.islandSceneInitializationModel = new IslandSceneInitializationModel(objectStaticPositioner, worldEditorObjectGenerator, parentGameObject);
        }

        private void Start()
        {
            this.islandSceneInitializationModel.SettingBuildingSystem();
        }
    }


}