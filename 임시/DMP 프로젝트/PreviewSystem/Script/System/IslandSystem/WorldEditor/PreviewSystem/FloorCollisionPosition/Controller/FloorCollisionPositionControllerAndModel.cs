using System.Collections;
using UnityEngine;

using Data.Temporay;

namespace System.BuildingSystem
{
    public class FloorCollisionPositionControllerAndModel : MonoBehaviour
    {
        private PreviewSystemData previewSystemData;

        [SerializeField] private AnimationCurve moveCurve;
        [SerializeField] private float duration;

        private float currentFloor;
        private float nextFloor;

        private void Awake()
        {
            this.previewSystemData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;
        }

        public void ChangeCollisionFloorLayer(float floor)
        {
            this.currentFloor = this.previewSystemData.FloorCollisionPosition;
            this.nextFloor = floor;

            StopAllCoroutines();
            StartCoroutine(MoveCollisionFloor());
        }

        private IEnumerator MoveCollisionFloor()
        {
            float currentTime = 0;
            float currentTimePercent = 0;

            while (currentTimePercent < 1)
            {
                currentTime += Time.deltaTime;
                currentTimePercent = currentTime / duration;

                this.previewSystemData.FloorCollisionPosition = Mathf.Lerp(this.currentFloor, this.nextFloor, this.moveCurve.Evaluate(currentTimePercent));
                this.previewSystemData.FloorCollisionPositionObserverSubject.NotifySubscribers();

                yield return null;
            }
        }
    }
}