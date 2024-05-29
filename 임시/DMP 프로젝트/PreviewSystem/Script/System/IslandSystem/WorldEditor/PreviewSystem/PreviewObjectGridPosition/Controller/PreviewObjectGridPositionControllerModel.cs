using UnityEngine;

using Data.Temporay;

namespace System.BuildingSystem
{
    public class PreviewObjectGridPositionControllerModel : MonoBehaviour
    {
        [SerializeField] private PositionConverter positionConverter;

        private PreviewSystemData previewObjectData;

        [SerializeField] private GameObject previewIndicator;
        [Tooltip("Indicator 중심을 기점으로 실질적으로 가리키는 위치 지정하기 위한 offset 입니다.")]
        [SerializeField] private float pointOffset;

        private LayerMask layerMask;

        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.layerMask =  LayerMask.GetMask("Floor");
        }

        public void OnDrag()
        {
            Vector2 previewObjectScreenPosition = this.previewIndicator.transform.position + new Vector3(0, this.pointOffset, 0);

            Vector3 worldActualPosition = this.positionConverter.ConvertScreenPositionToWorldPosition(previewObjectScreenPosition, this.layerMask);
            Vector3Int previewObjectGridPosition = this.positionConverter.ConvertWorldPositionToGridCell(worldActualPosition);

            // 데이터 클래스에 기록하면서, ObserverNotify 됨.
            this.previewObjectData.PreviewObjectGridPosition = previewObjectGridPosition;
            this.previewObjectData.PreviewObjectGridPositionObserverSubject.NotifySubscribers();
        }
    }
}
