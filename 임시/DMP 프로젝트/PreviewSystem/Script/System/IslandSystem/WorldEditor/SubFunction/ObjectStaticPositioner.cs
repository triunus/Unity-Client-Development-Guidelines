using UnityEngine;

using Data.Storage.Dynamic;

namespace System.BuildingSystem
{
    public class ObjectStaticPositioner : MonoBehaviour
    {
        [SerializeField] private PositionConverter positionConverter;

        /// <summary>
        /// ȭ���� Ŭ���Ǵ� �κ��� Ray�� ��ü�� ��ϵ� LayerMask�� �浹�Ǵ� ������ 3���� ���� ��ǥ�� ��ȯ�մϴ�.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector2 screenPosition, LayerMask layerMask)
        {
            Vector3 worldPosition = this.positionConverter.ConvertScreenPositionToWorldPosition(screenPosition, layerMask);

            this.PositionObjectToWorldPosition(gameObject, worldPosition);
        }
        /// <summary>
        /// ������ ���� ����� ���� ����ü Vector3IntData �� ���ǵ�  Grid ��ǥ�� 3���� ���� ��ǥ�� �������ݴϴ�.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector3IntData structGridPosition)
        {
            Vector3Int gridPosition = new Vector3Int(structGridPosition.X, structGridPosition.Y, structGridPosition.Z);

//            Debug.Log($"structGridPosition : ({structGridPosition.X}, {structGridPosition.Y}, {structGridPosition.Z}), gridPosition : {gridPosition}");

            this.PositionObjectToWorldPosition(gameObject, gridPosition);
        }
        /// <summary>
        /// Grid ��ǥ�� 3���� ���� ��ǥ�� �������ݴϴ�.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector3Int gridPosition)
        {
            Vector3 worldPosition = this.positionConverter.ConvertGridCellToWorldPosition(gridPosition);

            this.PositionObjectToWorldPosition(gameObject, worldPosition);
        }
        /// <summary>
        /// ��ü�� 3���� ���� ��ǥ�� �ٷ� ��ġ�� �ݴϴ�.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector3 worldPosition)
        {
            gameObject.transform.position = worldPosition;
        }
    }
}