using System.Collections;
using UnityEngine;

using Data.Temporay;
using DesignPattern.Observer;
using Data;

namespace System.BuildingSystem
{
    public class StructureObjectRotationTypeView_PreviewObject : MonoBehaviour, IObserverSubscriber
    {
        private PreviewSystemData previewObjectData;

        private IObserverSubject<StructureObjectRotationType> structurePreviewRotationObserverSubject;

        private Quaternion currentRotaion;
        private Quaternion nextRotation;

        [SerializeField] private AnimationCurve moveCurve;
        [SerializeField] private float duration;

        private void Awake()
        {
            this.previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;

            this.structurePreviewRotationObserverSubject = this.previewObjectData.StructureObjectRotationTypeObserverSubject;
        }
        private void OnEnable()
        {
            this.structurePreviewRotationObserverSubject.RegisterObserver(this);

        }
        private void OnDisable()
        {
            this.structurePreviewRotationObserverSubject.RemoveObserver(this);
        }

        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.StructureObjectRotationType:
                    this.UpdatePreviewObjectRotationObserverData();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePreviewObjectRotationObserverData()
        {
            StructureObjectRotationType nextStructureRotationType = this.structurePreviewRotationObserverSubject.GetObserverData();

            this.currentRotaion = this.previewObjectData.PreviewStructureObject.transform.GetChild(0).transform.localRotation;
            this.nextRotation = Quaternion.Euler(new Vector3(0, (int)nextStructureRotationType * 90, 0));

            StopAllCoroutines();
            StartCoroutine(RotatePreviewObject());
        }

        private IEnumerator RotatePreviewObject()
        {
            float currentTime = 0;
            float cureentTimePercent = 0;

            while (cureentTimePercent < 1)
            {
                currentTime += Time.deltaTime;
                cureentTimePercent = currentTime / duration;

                Quaternion rotatedValue = Quaternion.Lerp(this.currentRotaion, this.nextRotation, this.moveCurve.Evaluate(cureentTimePercent));

                this.previewObjectData.PreviewStructureObject.transform.GetChild(0).transform.localRotation = rotatedValue;
                this.previewObjectData.PreviewFloorObject.transform.GetChild(0).transform.localRotation = rotatedValue;

                yield return null;
            }
        }
    }
}