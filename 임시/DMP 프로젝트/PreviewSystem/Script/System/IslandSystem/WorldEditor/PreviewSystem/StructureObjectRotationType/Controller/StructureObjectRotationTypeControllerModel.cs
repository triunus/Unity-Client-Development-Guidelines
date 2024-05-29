using UnityEngine;

using Data;
using Data.Temporay;

namespace System.BuildingSystem
{
    public class StructureObjectRotationTypeControllerModel : MonoBehaviour
    {
        private PreviewSystemData previewObjectData;

        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;
        }

        /// <summary>
        /// isClockWise == true : �ð� ����
        /// isClockWise == false : �ݽð� ����.
        /// </summary>
        /// <param name="isClockWise"></param>
        public void RotatePreviewObjectRotation(bool isClockWise)
        {
            this.previewObjectData.StructureObjectRotationType = this.RotateRotation(isClockWise);
            this.previewObjectData.StructureObjectRotationTypeObserverSubject.NotifySubscribers();
        }
        private StructureObjectRotationType RotateRotation(bool isClockWise)
        {
            int nextRotationValue;

            if (isClockWise) nextRotationValue = (int)this.previewObjectData.StructureObjectRotationType + 1;
            else nextRotationValue = (int)this.previewObjectData.StructureObjectRotationType - 1;

            switch (nextRotationValue)
            {
                case -1:
                    nextRotationValue = 3;
                    break;
                case 0:
                    break;
                case 1:
                    nextRotationValue = 0;
                    break;
                case 2:
                    nextRotationValue = 3;
                    break;
                case 3:
                    break;
                case 4:
                    nextRotationValue = 0;
                    break;
            }

            return (StructureObjectRotationType)nextRotationValue;
        }
    }
}