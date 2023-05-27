using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterRagdoller : MonoBehaviour
    {
        [SerializeField] private Transform _ragdollRoot;
        
        private CapsuleCollider _mainCollider;
        private Animator _animator;
        
        private Collider[] _ragdollColliders;
        private Rigidbody[] _ragdollRigidbodies;

        private void Awake()
        {
            _mainCollider = GetComponent<CapsuleCollider>();
            _animator = GetComponentInChildren<Animator>();

            _ragdollColliders = _ragdollRoot.GetComponentsInChildren<Collider>();
            _ragdollRigidbodies = _ragdollRoot.GetComponentsInChildren<Rigidbody>();
            
            SetRagdollState(false);
        }

        [ContextMenu(nameof(DoRagdoll))]
        public void DoRagdoll()
        {
            SetRagdollState(true);
        }

        [ContextMenu(nameof(UnRagdoll))]
        public void UnRagdoll()
        {
            SetRagdollState(false);

            // сборосить позицию корня персонажа
            ResetPosition();
        }

        private void ResetPosition()
        {
            Vector3 centerPos = Vector3.zero;
            foreach (var rigidbody in _ragdollRigidbodies)
            {
                centerPos += rigidbody.position;
            }

            centerPos /= _ragdollRigidbodies.Length;

            transform.position = centerPos;
        }

        private void SetRagdollState(bool isRagdoll)
        {
            _mainCollider.enabled = !isRagdoll;
            _animator.enabled = !isRagdoll;

            foreach (var ragdollCollider in _ragdollColliders)
            {
                ragdollCollider.enabled = isRagdoll;
            }
            foreach (var ragdollRigidbody in _ragdollRigidbodies)
            {
                ragdollRigidbody.isKinematic = !isRagdoll;
            }
        }
    }
}