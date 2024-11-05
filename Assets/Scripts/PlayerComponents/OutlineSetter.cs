using UnityEngine;

namespace PlayerComponents
{
    public class OutlineSetter
    {
        private IMaterailChangerContainer _hoveredItem;
        private IMaterailChangerContainer _hoveredPickupTruck;

        public void SetOutline(bool isItemHit, IMaterailChangerContainer item, bool isPickupTruckHit, IMaterailChangerContainer pickupTruck)
        {
            TrySetOutline(isItemHit, item, ref _hoveredItem);
            TrySetOutline(isPickupTruckHit, pickupTruck, ref _hoveredItem);

            if (isItemHit == false && isPickupTruckHit == false)
            {
                if (_hoveredItem != null) _hoveredItem.MaterialChanger.SetDefaultMaterial();
                _hoveredItem = null;
            }
        }
        
        private void TrySetOutline(bool isItemHit, IMaterailChangerContainer item, ref IMaterailChangerContainer hoveredItem)
        {
            if (hoveredItem != null && isItemHit == false)
            {
            }

            if (isItemHit == true)
            {
                item.MaterialChanger.SetOutlineMaterial();
                hoveredItem = item;
            }
        }
    }
}