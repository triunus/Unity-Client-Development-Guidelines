using UnityEngine;
using UnityEngine.EventSystems;

namespace System.BuildingSystem
{
    public class PreviewIndicatorPositionControllerAndView : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        [SerializeField] private GameObject indicator;

        // ����ڰ� indicator�� Ŭ���ϴ� ������ indicator �߽� �������� �Ÿ��� ���մϴ�.
        private Vector2 distanceBetweenIndicatorCenterAndHitPoint;

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.distanceBetweenIndicatorCenterAndHitPoint =
                new Vector2(this.indicator.transform.position.x - eventData.position.x, this.indicator.transform.position.y - eventData.position.y);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Indicator ��ġ ����.
            this.indicator.transform.position = eventData.position + this.distanceBetweenIndicatorCenterAndHitPoint;
        }
    }
}