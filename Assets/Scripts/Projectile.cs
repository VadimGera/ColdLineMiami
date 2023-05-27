using System;
using DefaultNamespace.Ai;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class Projectile : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);

            TryDealDamage(collision.gameObject);
        }

        private void TryDealDamage(GameObject other)
        {
            if (other.TryGetComponent<CharacterRagdoller>(out var ragdoller))
            {
                ragdoller.DoRagdoll();
            }
            if (other.TryGetComponent<AimInput>(out var aim))
            {
                aim.enabled = false;
            }
            if (other.TryGetComponent<PlayerInput>(out var input))
            {
                input.enabled = false;
            }
            if (other.TryGetComponent<StateMachine>(out var stateMachine))
            {
                stateMachine.enabled = false;
            }
            if (other.TryGetComponent<NavMeshAgent>(out var nma))
            {
                nma.enabled = false;
            }
        }
    }
}