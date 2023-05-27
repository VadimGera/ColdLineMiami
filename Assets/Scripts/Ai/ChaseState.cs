using UnityEngine;

namespace DefaultNamespace.Ai
{
    public class ChaseState : IState
    {
        private readonly IMoveController _moveController;
        private readonly DetectionTrigger _detectionTrigger;
        private readonly StateMachine _stateMachine;
        private readonly Transform _transform;

        public ChaseState(StateMachine stateMachine)
        {
            _moveController = stateMachine.GetComponent<IMoveController>();
            _detectionTrigger = stateMachine.GetComponentInChildren<DetectionTrigger>();
            _transform = stateMachine.transform;
            
            
            _stateMachine = stateMachine;
        }
        
        public void Tick()
        {
            var playerPos = CharactersManager.Instance.Player.transform.position;
            
            var playerPos2 = new Vector2(playerPos.x, playerPos.z);
            _moveController.Move(playerPos2);
        }

        public IState GetNextState()
        {
            if (_detectionTrigger.IsPlayerInTrigger && AimUtils.CanSeePlayer(_transform))
            {
                return _stateMachine.Attack;
            }
            return this;
        }
    }
}