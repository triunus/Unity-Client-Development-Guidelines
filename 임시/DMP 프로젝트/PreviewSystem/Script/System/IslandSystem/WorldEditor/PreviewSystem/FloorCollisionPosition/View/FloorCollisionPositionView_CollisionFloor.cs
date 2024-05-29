using UnityEngine;

using DesignPattern.Observer;
using Data;
using Data.Temporay;

namespace System.BuildingSystem
{
    public class FloorCollisionPositionView_CollisionFloor : MonoBehaviour, IObserverSubscriber
    {
        private PreviewSystemData previewObjectData;

        private IObserverSubject<float> floorCollisionPositionObserverSubject;

        [SerializeField] GameObject collisionFloor;

        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.floorCollisionPositionObserverSubject = this.previewObjectData.FloorCollisionPositionObserverSubject;
        }

        private void OnEnable()
        {
            this.floorCollisionPositionObserverSubject.RegisterObserver(this);
        }
        private void OnDisable()
        {
            this.floorCollisionPositionObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.FloorCollisionPosition:
                    this.UpdateCollisionFloorByFloorCollisionPosition();
                    break;
                default:
                    break;
            }
        }

        private void UpdateCollisionFloorByFloorCollisionPosition()
        {
            float floorLayer = this.floorCollisionPositionObserverSubject.GetObserverData();

            this.collisionFloor.gameObject.transform.position = new Vector3(0, floorLayer, 0);
        }
    }
}