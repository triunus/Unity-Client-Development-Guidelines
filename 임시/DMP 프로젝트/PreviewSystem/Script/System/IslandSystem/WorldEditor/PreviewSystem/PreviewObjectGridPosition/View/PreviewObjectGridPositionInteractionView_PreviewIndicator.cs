using UnityEngine;
using UnityEngine.EventSystems;

namespace System.BuildingSystem
{
    public class PreviewObjectGridPositionInteractionView_PreviewIndicator : MonoBehaviour, IDragHandler
    {
        [SerializeField] private PreviewObjectGridPositionControllerModel previewObjectGridPositionControllerModel;

        public void OnDrag(PointerEventData eventData)
        {
            this.previewObjectGridPositionControllerModel.OnDrag();
        }
    }
}