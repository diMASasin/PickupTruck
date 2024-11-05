using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class IncreaseDecreaseAnimation : MonoBehaviour
    {
        [SerializeField] private float _targetScale = 1.1f;
        [SerializeField] private float _increaseDuration = 0.2f;
        [SerializeField] private float _decreaseDuration = 0.2f;

        private Vector3 _initialScale;
        
        private void Awake()
        {
            _initialScale = transform.localScale;
        }

        public void Play()
        {
            transform
                .DOScale(_targetScale, _increaseDuration)
                .OnComplete(() => transform.DOScale(_initialScale, _decreaseDuration));
        }
    }
}