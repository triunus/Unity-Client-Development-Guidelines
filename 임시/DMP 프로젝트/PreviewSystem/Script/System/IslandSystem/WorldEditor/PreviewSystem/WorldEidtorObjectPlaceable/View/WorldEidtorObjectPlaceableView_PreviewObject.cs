using UnityEngine;

using Data.Temporay;
using DesignPattern.Observer;
using Data;

namespace System.BuildingSystem
{
    public class WorldEidtorObjectPlaceableView_PreviewObject : MonoBehaviour, IObserverSubscriber
    {
        private IObserverSubject<bool> worldEidtorObjectPlaceableObserverSubject;

        private void Awake()
        {
            this.worldEidtorObjectPlaceableObserverSubject = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData.WorldEidtorObjectPlaceableObserverSubject;
        }
        private void OnEnable()
        {
            this.worldEidtorObjectPlaceableObserverSubject.RegisterObserver(this);
        }
        private void OnDisable()
        {
            this.worldEidtorObjectPlaceableObserverSubject.RemoveObserver(this);
        }


        public void UpdateObserverData(ObserverType observerType)
        {
            switch (observerType)
            {
                case ObserverType.WorldEidtorObjectPlaceable:
                    this.UpdatePreviewObjectMaterial();
                    break;
                default:
                    break;
            }
        }

        private void UpdatePreviewObjectMaterial()
        {
            PreviewSystemData previewObjectData = TemporaryDynamicData.Instance.IslandSceneData.WorldEditorData.PreviewSystemData;
            bool placeable = this.worldEidtorObjectPlaceableObserverSubject.GetObserverData();

            if(previewObjectData.PreviewFoliageMaterialPrefab != null)
            {
                if (placeable)
                {
                    previewObjectData.PreviewFoliageMaterialPrefab.SetInt("_IsNotPlaceable", 0);
                }
                else
                {
                    previewObjectData.PreviewFoliageMaterialPrefab.SetInt("_IsNotPlaceable", 1);
                }
            }


            Color color = placeable ? Color.white : Color.red;
            color.a = 0.5f;
            if (previewObjectData.PreviewMaterialPrefab != null)
            {
                previewObjectData.PreviewMaterialPrefab.color = color;
            }
        }
    }
}