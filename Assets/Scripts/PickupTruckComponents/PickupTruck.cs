using System;
using System.Linq;
using ItemComponents;
using PlayerComponents;
using UnityEngine;

namespace PickupTruckComponents
{
    public class PickupTruck : MonoBehaviour, IMaterailChangerContainer
    {
        [SerializeField] private BaggagePoint[] _baggagePoints;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _outlineMaterial;
        [SerializeField] private Material _defaultMaterial;
        [field: SerializeField] public MaterialChanger MaterialChanger { get; private set; }

        public event Action ItemPut;


        public bool TryPutItem(Item item)
        {
            BaggagePoint freePoint = _baggagePoints.FirstOrDefault(point => point.IsOcuppied == false);

            if (freePoint != null)
            {
                freePoint.Put(item);
                ItemPut?.Invoke();
                return true;
            }

            return false;
        }

        public void SetOutlineMaterial() => _meshRenderer.material = _outlineMaterial;
        public void SetDefaultMaterial() => _meshRenderer.material = _defaultMaterial;
    }
}