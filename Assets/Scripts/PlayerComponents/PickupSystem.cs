using ItemComponents;
using PickupTruckComponents;
using UnityEngine;

namespace PlayerComponents
{
    public class PickupSystem : MonoBehaviour
    {
        [SerializeField] private Transform _itemPosition;
        [SerializeField] private float _raycastDistance = 3f;

        private Camera _camera;
        private Item _itemInHand;
        private IPlayerInput _playerInput;
        private OutlineSetter _outlineSetter;

        public void Init(IPlayerInput playerInput, OutlineSetter outlineSetter, Camera camera)
        {
            _playerInput = playerInput;
            _outlineSetter = outlineSetter;
            _camera = camera;
        }
    
        private void Update()
        {
            bool raycast = GetRaycastData(out bool isItemHit, out var item, out bool isPickupTruckHit, out var pickupTruck);

            if (_playerInput.GetInteractKeyDown())
            {
                if (TryPickup(raycast, isItemHit, item) == true)
                    return;

                if (raycast == true && isPickupTruckHit && _itemInHand != null)
                    TryPut(pickupTruck);
                else if(_itemInHand != null)
                    Drop();
            }
            
            _outlineSetter.SetOutline(isItemHit, item, isPickupTruckHit, pickupTruck);
        }

        private bool GetRaycastData(out bool isItemHit, out Item item, out bool isPickupTruckHit, out PickupTruck pickupTruck)
        {
            bool raycast = Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hitInfo,
                _raycastDistance);

            isItemHit = false;
            item = null;
            isPickupTruckHit = false;
            pickupTruck = null;

            if (raycast == true)
            {
                isItemHit = hitInfo.transform.TryGetComponent(out item);
                isPickupTruckHit = hitInfo.transform.TryGetComponent(out pickupTruck);
            }

            return raycast;
        }

        private bool TryPickup(bool raycast, bool isItemHit, Item item)
        {
            if (raycast == true && isItemHit == true && _itemInHand == null)
            {
                Pickup(item);
                return true;
            }

            return false;
        }

        private void Pickup(Item item)
        {
            _itemInHand = item;
            _itemInHand.transform.parent = _itemPosition.transform;
            _itemInHand.transform.localPosition = Vector3.zero;
            _itemInHand.transform.rotation = Quaternion.identity;
            item.SetUseGravity(false);
            item.DisableCollider();
            item.FreezeAll();
        }

        private void TryPut(PickupTruck pickupTruck)
        {
            if (pickupTruck.TryPutItem(_itemInHand)) 
                _itemInHand = null;
        }

        private void Drop()
        {
            _itemInHand.transform.parent = null;
            _itemInHand.SetUseGravity(true);
            _itemInHand.EnableCollider();
            _itemInHand.Unfreeze();
            _itemInHand = null;
        }
    }
}