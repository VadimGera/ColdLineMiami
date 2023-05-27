using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInput : MonoBehaviour
    {
        private IMoveController _controller;

        private void Awake()
        {
            _controller = GetComponent<IMoveController>();
        }

        private void FixedUpdate()
        {
            var forwardInput = 0f;
            var rightInput = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                forwardInput = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                forwardInput = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rightInput = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rightInput = 1f;
            }

            var inputVector = new Vector2(rightInput, forwardInput);
            _controller.Move(inputVector.normalized);
        }
    }
}