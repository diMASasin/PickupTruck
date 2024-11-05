using Animations;
using LevelComponents;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ProgressView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private IncreaseDecreaseAnimation _increaseDecreaseAnimation;
        
        private EndCondition _endCondition;
        private int _itemsToWin;
        private ILevelEvents _levelEvents;

        public void Init(EndCondition endCondition, int itemsToWin, ILevelEvents levelEvents)
        {
            _levelEvents = levelEvents;
            _itemsToWin = itemsToWin;
            _endCondition = endCondition;
            
            _endCondition.ItemsPutValueChanged += OnItemPut;
            _levelEvents.LevelComplete += OnLevelComplete;
            
            OnItemPut(0);
        }

        private void OnDestroy()
        {
            _endCondition.ItemsPutValueChanged -= OnItemPut;
            _levelEvents.LevelComplete -= OnLevelComplete;
        }

        private void OnLevelComplete()
        {
            _text.color = Color.green;
            _increaseDecreaseAnimation.Play();
        }

        private void OnItemPut(int itemsPut) => _text.text = $"Items collected: {itemsPut} / {_itemsToWin}";
    }
}