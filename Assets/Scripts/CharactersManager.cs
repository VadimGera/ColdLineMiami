using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CharactersManager : MonoBehaviour
    {
        public static CharactersManager Instance { get; private set; }
        
        public PlayerCharacterController Player { get; private set; }
        public BotCharacterController[] Bots { get; private set; }

        private void Awake()
        {
            Player = FindObjectOfType<PlayerCharacterController>();
            Bots = FindObjectsOfType<BotCharacterController>();

            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
    }
}