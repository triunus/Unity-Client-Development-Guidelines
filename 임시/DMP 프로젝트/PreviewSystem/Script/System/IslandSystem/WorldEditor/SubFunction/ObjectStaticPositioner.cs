using UnityEngine;

using Data.Storage.Dynamic;

namespace System.BuildingSystem
{
    public class ObjectStaticPositioner : MonoBehaviour
    {
        [SerializeField] private PositionConverter positionConverter;

        /// <summary>
        /// 화면이 클릭되는 부분의 Ray와 객체에 등록된 LayerMask가 충돌되는 지점의 3차원 월드 좌표를 반환합니다.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector2 screenPosition, LayerMask layerMask)
        {
            Vector3 worldPosition = this.positionConverter.ConvertScreenPositionToWorldPosition(screenPosition, layerMask);

            this.PositionObjectToWorldPosition(gameObject, worldPosition);
        }
        /// <summary>
        /// 저장을 위해 사용자 정의 구조체 Vector3IntData 로 정의된  Grid 좌표를 3차원 월드 좌표로 변경해줍니다.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector3IntData structGridPosition)
        {
            Vector3Int gridPosition = new Vector3Int(structGridPosition.X, structGridPosition.Y, structGridPosition.Z);

//            Debug.Log($"structGridPosition : ({structGridPosition.X}, {structGridPosition.Y}, {structGridPosition.Z}), gridPosition : {gridPosition}");

            this.PositionObjectToWorldPosition(gameObject, gridPosition);
        }
        /// <summary>
        /// Grid 좌표를 3차원 월드 좌표로 변경해줍니다.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector3Int gridPosition)
        {
            Vector3 worldPosition = this.positionConverter.ConvertGridCellToWorldPosition(gridPosition);

            this.PositionObjectToWorldPosition(gameObject, worldPosition);
        }
        /// <summary>
        /// 객체를 3차원 월드 좌표에 바로 배치해 줍니다.
        /// </summary>
        public void PositionObjectToWorldPosition(GameObject gameObject, Vector3 worldPosition)
        {
            gameObject.transform.position = worldPosition;
        }
    }
}