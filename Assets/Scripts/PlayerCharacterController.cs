using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerCharacterController : MonoBehaviour, IMoveController
    {
        [SerializeField] private float _maxSpeed = 2f;
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _stoppingSpeed = 1f;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void Move(Vector2 direction)
        {
            var force = new Vector3(direction.x, 0, direction.y) * _moveSpeed;

            if (force.magnitude > 0f)
            {
                if (_rigidbody.velocity.magnitude < _maxSpeed)
                {
                    _rigidbody.AddForce(force);
                }
            }
            else // если не жмём кнопки
            {
                _rigidbody.velocity *= _stoppingSpeed * Time.fixedDeltaTime;
            }
        }
    }
}