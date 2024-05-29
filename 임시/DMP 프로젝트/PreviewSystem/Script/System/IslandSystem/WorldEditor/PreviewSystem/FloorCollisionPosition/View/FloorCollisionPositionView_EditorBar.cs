using UnityEngine;

using Data.Temporay;
using DesignPattern.Observer;
using Data;

namespace System.BuildingSystem
{
    public class FloorCollisionPositionView_EditorBar : MonoBehaviour, IObserverSubscriber
    {
        [SerializeField] private PositionConverter positionConverter;

        private PreviewSystemData previewObjectData;

        private IObserverSubject<float> floorCollisionPositionObserverSubject;

        [SerializeField] private GameObject editorBar;
        [Tooltip("PreviewObject의 ScreenPosiion을 기점에서부터 EditorBar의 거리를 말합니다.")]
        [SerializeField] private float distanceOffset;


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
                    this.UpdatePreviewObjectByFloorLayer();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePreviewObjectByFloorLayer()
        {
            // 현재 PreviewObject 위치.
            Vector3Int previewObjectGridPosition = this.previewObjectData.PreviewObjectGridPosition;
            Vector3 previewObjectWorldPosition = this.positionConverter.ConvertGridCellToWorldPosition(previewObjectGridPosition) + new Vector3(1.5f, 0, 1.5f); ;

            // 증가하는 Floor 값.
            float floorLayer = this.floorCollisionPositionObserverSubject.GetObserverData();

            // 증가하고 있는 PreviewObject 위치.
            Vector3 previewObjectWorldPositionWithFloor = new Vector3(previewObjectWorldPosition.x, floorLayer, previewObjectWorldPosition.z);
            Vector2 previewObjectScreenPosition = this.positionConverter.ConvertWorldPositionToScreenPosition(previewObjectWorldPositionWithFloor);

            // editorBar 중심 위치.
            Vector2 editorBarCenterPosition = previewObjectScreenPosition + new Vector2(0, distanceOffset);

            this.editorBar.transform.position = editorBarCenterPosition;
        }
    }
}