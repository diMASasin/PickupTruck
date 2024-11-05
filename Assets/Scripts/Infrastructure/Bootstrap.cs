using LevelComponents;
using PickupTruckComponents;
using UI;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PickupTruck _pickupTruck;
    [SerializeField] private ProgressView _progressView;
    
    private readonly int _itemsToWin = 9;
    
    private EndCondition _defaultCondition;
    private Level _level;

    private void Start()
    {
        _defaultCondition = new EndCondition(itemsPut => itemsPut >= _itemsToWin, _pickupTruck);
        _level = new Level(_defaultCondition);
        _progressView.Init(_defaultCondition, _itemsToWin, _level);
    }

    private void OnDestroy()
    {
        _defaultCondition.Dispose();
        _level.Dispose();
    }
}