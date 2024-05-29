using UnityEngine;

using DesignPattern.Observer;
using Mediator.Activation;

using Data;
using Data.Temporay;

namespace System.BuildingSystem
{
    public class PreviewObjectDataInitializationModel
    {
        private PreviewObjectDataInitializer previewObjectDataInitializer;

        private PreviewSystemData previewObjectData;

        // 기능 시작 시, 활성화되는 객체를 명시. 
        private GameObjectActivationMediatorView gameObjectActivationMediatorView;

        public PreviewObjectDataInitializationModel(Transform previewParentGameObject, GameObjectActivationMediatorView gameObjectActivationMediatorView)
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.previewObjectDataInitializer = new PreviewObjectDataInitializer(previewObjectData: this.previewObjectData, previewParentGameObject: previewParentGameObject);
            this.gameObjectActivationMediatorView = gameObjectActivationMediatorView;
        }

        public void InitialSetting()
        {
            this.previewObjectDataInitializer.InitialSetting();

            // 객체들 활성화
            this.gameObjectActivationMediatorView.SetActive(0);

            // 공지
            this.previewObjectData.FloorCollisionPositionObserverSubject.NotifySubscribers();
            this.previewObjectData.PreviewObjectGridPositionObserverSubject.NotifySubscribers();
            this.previewObjectData.StructureObjectRotationTypeObserverSubject.NotifySubscribers();
        }

        public void Clear()
        {
            this.previewObjectDataInitializer.Clear();

            // 객체들 비활성화
            this.gameObjectActivationMediatorView.SetActive(1);
        }
    }

    public class PreviewObjectDataInitializationController : MonoBehaviour, IObserverSubscriber
    {
        private PreviewObjectDataInitializationModel previewObjectDataInitializationModel;

        // PreviewObject의 부모 객체.
        [SerializeField] private Transform previewParentGameObject;

        // 기능 시작 시, 활성화되는 객체를 명시. 
        [SerializeField] private GameObjectActivationMediatorView gameObjectActivationMediatorView;

        private IObserverSubject<bool> isBuildingSystemOperatingObserverSubject;

        private void Awake()
        {
            this.previewObjectDataInitializationModel = new PreviewObjectDataInitializationModel(previewParentGameObject, gameObjectActivationMediatorView);

            this.isBuildingSystemOperatingObserverSubject = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.BuildingSystemData.IsBuildingSystemOperatingObserverSubject;
        }

        private void OnEnable()
        {
            this.isBuildingSystemOperatingObserverSubject.RegisterObserver(this);
        }

        private void OnDisable()
        {
            this.isBuildingSystemOperatingObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.IsBuildingSystemOperating:
                    this.UpdatePreviewObjectData();
                    break;
                default:
                    break;
            }
        }

        public void UpdatePreviewObjectData()
        {
            bool isBuildingSystemOperating = this.isBuildingSystemOperatingObserverSubject.GetObserverData();

            if (isBuildingSystemOperating)
            {
                this.previewObjectDataInitializationModel.InitialSetting();
            }
            else
            {
                this.previewObjectDataInitializationModel.Clear();
            }
        }
    }
}