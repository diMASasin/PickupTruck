using System;
using PickupTruckComponents;

namespace LevelComponents
{
    public class EndCondition : IDisposable
    {
        private readonly Func<int, bool> _isLevelEnd;
        private readonly PickupTruck _pickupTruck;

        private int _itemsPut;

        public event Action<int> ItemsPutValueChanged;
        public event Action End;
        
        public EndCondition(Func<int, bool> isLevelEnd, PickupTruck pickupTruck)
        {
            _pickupTruck = pickupTruck;
            _isLevelEnd = isLevelEnd;
            
            _pickupTruck.ItemPut += OnItemPut;
        }

        public void Dispose()
        {
            _pickupTruck.ItemPut -= OnItemPut;
        }

        private void OnItemPut()
        {
            _itemsPut++;
            ItemsPutValueChanged?.Invoke(_itemsPut);
            
            if(_isLevelEnd(_itemsPut) == true)
                End?.Invoke();
        }
    }
}