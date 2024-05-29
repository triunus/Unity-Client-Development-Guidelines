using UnityEngine;

using Data.Temporay;
using DesignPattern.Observer;
using Data;

namespace System.BuildingSystem
{
    public class PreviewObjectGridPositionView_EditorBar : MonoBehaviour, IObserverSubscriber
    {
        [SerializeField] private PositionConverter positionConverter;

        private PreviewSystemData previewObjectData;

        private IObserverSubject<Vector3Int> previewObjectGridPositionObserverSubject;

        [SerializeField] private GameObject editorBar;
        [Tooltip("PreviewObject의 ScreenPosiion을 기점에서부터 EditorBar의 거리를 말합니다.")]
        [SerializeField] private float distanceOffset;


        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.previewObjectGridPositionObserverSubject = this.previewObjectData.PreviewObjectGridPositionObserverSubject;
        }
        private void OnEnable()
        {
            this.previewObjectGridPositionObserverSubject.RegisterObserver(this);
        }
        private void OnDisable()
        {
            this.previewObjectGridPositionObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.PreviewObjectGridPosition:
                    this.UpdatePreviewObjectByPreviousObjectGridPosition();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePreviewObjectByPreviousObjectGridPosition()
        {
            Vector3Int previewObjectGridPosition = this.previewObjectGridPositionObserverSubject.GetObserverData();

            Vector3 previewObjectWorldPosition = this.positionConverter.ConvertGridCellToWorldPosition(previewObjectGridPosition) + new Vector3(1.5f, 0, 1.5f);
            Vector2 previewObjectScreenPosition = this.positionConverter.ConvertWorldPositionToScreenPosition(previewObjectWorldPosition);

            Vector2 eidtorBarCenterPosition = previewObjectScreenPosition + new Vector2(0, distanceOffset);

            this.editorBar.transform.position = eidtorBarCenterPosition;
        }
    }
}