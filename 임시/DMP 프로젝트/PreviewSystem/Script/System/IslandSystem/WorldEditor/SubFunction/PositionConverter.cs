using UnityEngine;

namespace System.BuildingSystem
{
    public class PositionConverter : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Camera sceneCamera;
        [SerializeField] private Grid grid;

        public Vector3 ConvertScreenPositionToWorldPosition(Vector2 screenPosition, LayerMask layerMask)
        {
            Vector3 result = Vector3.zero;

            Ray ray = this.sceneCamera.ScreenPointToRay(screenPosition);
            RaycastHit hitPoint;

            if (Physics.Raycast(ray, out hitPoint, Mathf.Infinity, layerMask))
            {
                result = hitPoint.point;
            }

            return result;
        }

        public Vector2 ConvertWorldPositionToScreenPosition(Vector3 worldPosition)
        {
            return this.sceneCamera.WorldToScreenPoint(worldPosition);
        }

        public Vector3Int ConvertWorldPositionToGridCell(Vector3 worldPosition)
        {
            return this.grid.WorldToCell(worldPosition);
        }

        public Vector3 ConvertGridCellToWorldPosition(Vector3Int gridCell)
        {
            return this.grid.CellToWorld(gridCell);
        }
    }
}
