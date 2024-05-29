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

        // ��� ���� ��, Ȱ��ȭ�Ǵ� ��ü�� ���. 
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

            // ��ü�� Ȱ��ȭ
            this.gameObjectActivationMediatorView.SetActive(0);

            // ����
            this.previewObjectData.FloorCollisionPositionObserverSubject.NotifySubscribers();
            this.previewObjectData.PreviewObjectGridPositionObserverSubject.NotifySubscribers();
            this.previewObjectData.StructureObjectRotationTypeObserverSubject.NotifySubscribers();
        }

        public void Clear()
        {
            this.previewObjectDataInitializer.Clear();

            // ��ü�� ��Ȱ��ȭ
            this.gameObjectActivationMediatorView.SetActive(1);
        }
    }

    public class PreviewObjectDataInitializationController : MonoBehaviour, IObserverSubscriber
    {
        private PreviewObjectDataInitializationModel previewObjectDataInitializationModel;

        // PreviewObject�� �θ� ��ü.
        [SerializeField] private Transform previewParentGameObject;

        // ��� ���� ��, Ȱ��ȭ�Ǵ� ��ü�� ���. 
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