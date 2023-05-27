using System;
using UnityEngine;

namespace DefaultNamespace.Ai
{
    public class DetectionTrigger : MonoBehaviour
    {
        [SerializeField] private string _playerTag = "Player";
        
        public bool IsPlayerInTrigger { get; private set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                IsPlayerInTrigger = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                IsPlayerInTrigger = false;
            }
        }
    }
}