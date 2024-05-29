using UnityEngine;

using Data.Temporay;

namespace System.BuildingSystem
{
    public class PreviewObjectGridPositionControllerModel : MonoBehaviour
    {
        [SerializeField] private PositionConverter positionConverter;

        private PreviewSystemData previewObjectData;

        [SerializeField] private GameObject previewIndicator;
        [Tooltip("Indicator �߽��� �������� ���������� ����Ű�� ��ġ �����ϱ� ���� offset �Դϴ�.")]
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

            // ������ Ŭ������ ����ϸ鼭, ObserverNotify ��.
            this.previewObjectData.PreviewObjectGridPosition = previewObjectGridPosition;
            this.previewObjectData.PreviewObjectGridPositionObserverSubject.NotifySubscribers();
        }
    }
}
