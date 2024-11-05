using PlayerComponents;
using UnityEngine;

namespace ItemComponents
{
    public class Item : MonoBehaviour, IMaterailChangerContainer
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _collider;
        [field: SerializeField] public MaterialChanger MaterialChanger { get; private set; }

        public void SetUseGravity(bool value)
        {
            _rigidbody.useGravity = value;
        }

        public void DisableCollider() => _collider.enabled = false;

        public void EnableCollider() => _collider.enabled = true;

        public void FreezeAll() => _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        public void Unfreeze() => _rigidbody.constraints = RigidbodyConstraints.None;
    }
}
