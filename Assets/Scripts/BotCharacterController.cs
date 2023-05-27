using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class BotCharacterController : MonoBehaviour, IMoveController
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void Move(Vector2 targetPosition)
        {
            _navMeshAgent.isStopped = false;
            var destination = new Vector3(targetPosition.x,
                transform.position.y,
                targetPosition.y);
            
            _navMeshAgent.destination = destination;
        }

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}