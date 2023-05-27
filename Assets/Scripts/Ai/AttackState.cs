using UnityEngine;

namespace DefaultNamespace.Ai
{
    public class AttackState : IState
    {
        private readonly float _attackDelay = 0.2f;
        private readonly float _minAngleToShoot = 2f;
        private readonly float _turnSmoothness = 5f;
        private float _attackTimer;
        
        private readonly StateMachine _stateMachine;
        private readonly DetectionTrigger _detectionTrigger;
        private readonly BotCharacterController _botCharacterController;
        private readonly WeaponController _weapon;
        private readonly Transform _transform;

        public AttackState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _transform = _stateMachine.transform;
            
            _botCharacterController = stateMachine.GetComponent<BotCharacterController>();
            _weapon = stateMachine.GetComponentInChildren<WeaponController>();
            _detectionTrigger = _stateMachine.GetComponentInChildren<DetectionTrigger>();
        }
        
        
        public void Tick()
        {
            _botCharacterController.Stop();

            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0f)
            {
                _attackTimer = _attackDelay;
                _weapon.Shot();
            }
            
            // повернуть плавно в сторону игрока
            var directionTowardsPlayer = CharactersManager.Instance.Player.transform.position - _transform.position;
            _transform.rotation = Quaternion.Lerp(_transform.rotation, 
                Quaternion.LookRotation(directionTowardsPlayer), 
                Time.deltaTime * _turnSmoothness);
            
            // todo повернуться в сторону игрока
        }

        public IState GetNextState()
        {
            if (!AimUtils.CanSeePlayer(_transform))
            {
                return _stateMachine.Chase;
            }
            return this;
        }
    }
}