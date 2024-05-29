using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*namespace TransformOperation
{
    public enum RatioCurveType
    {
        Non
    }

    public static class TimeRatioCurve
    {
        public static float GetCurveRatioAtTime(RatioCurveType ratioCurveType)
        {
            float value = 1;

            switch (ratioCurveType)
            {
                case RatioCurveType.Non:
                    value = TimeRatioCurve.GetLinerRatioAtTime();
                    break;
                default:
                    break;
            }

            return value;
        }

        private static float GetLinerRatioAtTime()
        {
            return AnimationCurve.Linear.Evaluate(currentTimePercent);
        }
    }
}*/

/*namespace TransformOperation
{
    public struct ObjectDynamicPositioningData
    {
        private GameObject targetGameObject;

        private Vector3 nextPosition;
        private AnimationCurve moveCurve;

        private float animationDuration;
        private float startDelay;
        private float endDelay;

        public ObjectDynamicPositioningData(
            GameObject targetGameObject, Vector3 nextPosition, AnimationCurve moveCurve,
            float animationDuration = 1, float startDelay = 0, float endDelay = 0)
        {
            this.targetGameObject = targetGameObject;

            this.nextPosition = nextPosition;
            this.moveCurve = moveCurve;

            this.startDelay = startDelay;
            this.animationDuration = animationDuration;
            this.endDelay = endDelay;
        }

        public int TargetGameObjectID { get => this.targetGameObject.GetInstanceID(); }

        public GameObject TargetGameObject { get => this.targetGameObject; }

        public Vector3 NextPosition { get => this.nextPosition; }
        public AnimationCurve MoveCurve { get => moveCurve; }

        public float AnimationDuration { get => this.animationDuration; }
        public float StartDelay { get => this.startDelay; }
        public float EndDelay { get => this.endDelay; }
    }

    public class ObjectDynamicPositioner : MonoBehaviour
    {
        private Dictionary<int, Coroutine> inPlayedCoroutines;

        private void Awake()
        {
            this.inPlayedCoroutines = new Dictionary<int, Coroutine>();
        }

        /// <summary>
        /// 객체를 3차원 월드 좌표에 코루틴으로 배치해 줍니다.
        /// </summary>
        public void PositionObjectToWorldPositionWithCoroutine(ObjectDynamicPositioningData objectDynamicPositioningData)
        {
            this.StopMoveCoroutine(objectDynamicPositioningData);
            this.StartMoveCoroutine(objectDynamicPositioningData);
        }

        private void StopMoveCoroutine(ObjectDynamicPositioningData objectDynamicPositioningData)
        {
            if (!this.inPlayedCoroutines.ContainsKey(objectDynamicPositioningData.TargetGameObjectID)) return;

            StopCoroutine(this.inPlayedCoroutines[objectDynamicPositioningData.TargetGameObjectID]);
            this.inPlayedCoroutines.Remove(objectDynamicPositioningData.TargetGameObjectID);
        }

        private void StartMoveCoroutine(ObjectDynamicPositioningData objectDynamicPositioningData)
        {
            Coroutine moveCoroutine = StartCoroutine(StartMove(objectDynamicPositioningData));

            this.inPlayedCoroutines.Add(objectDynamicPositioningData.TargetGameObjectID, moveCoroutine);
        }

        private IEnumerator StartMove(ObjectDynamicPositioningData objectDynamicPositioningData)
        {
            float currentTime = 0;
            float currentTimePercent = 0;

            Vector3 currentPosition = objectDynamicPositioningData.TargetGameObject.transform.position;

            while (currentTimePercent < 1)
            {
                currentTime += Time.deltaTime;
                currentTimePercent = currentTime / objectDynamicPositioningData.AnimationDuration;

                objectDynamicPositioningData.TargetGameObject.transform.position =
                    Vector3.Lerp(currentPosition, objectDynamicPositioningData.NextPosition,
                    objectDynamicPositioningData.MoveCurve.Evaluate(currentTimePercent));

                yield return null;
            }

            if (this.inPlayedCoroutines.ContainsKey(objectDynamicPositioningData.TargetGameObjectID))
            {
                this.inPlayedCoroutines.Remove(objectDynamicPositioningData.TargetGameObjectID);
            }
        }
    }
}*/