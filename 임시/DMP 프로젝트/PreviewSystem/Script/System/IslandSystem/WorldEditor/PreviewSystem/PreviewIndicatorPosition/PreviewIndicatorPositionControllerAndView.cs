using UnityEngine;
using UnityEngine.EventSystems;

namespace System.BuildingSystem
{
    public class PreviewIndicatorPositionControllerAndView : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        [SerializeField] private GameObject indicator;

        // 사용자가 indicator를 클릭하는 지점과 indicator 중심 지점과의 거리를 말합니다.
        private Vector2 distanceBetweenIndicatorCenterAndHitPoint;

        public void OnBeginDrag(PointerEventData eventData)
        {
            this.distanceBetweenIndicatorCenterAndHitPoint =
                new Vector2(this.indicator.transform.position.x - eventData.position.x, this.indicator.transform.position.y - eventData.position.y);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Indicator 위치 지정.
            this.indicator.transform.position = eventData.position + this.distanceBetweenIndicatorCenterAndHitPoint;
        }
    }
}