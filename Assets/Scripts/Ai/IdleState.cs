using UnityEngine;

namespace DefaultNamespace.Ai
{
    public class IdleState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly DetectionTrigger _detectionTrigger;
        private readonly Transform _transform;

        public IdleState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _transform = stateMachine.transform;

            _detectionTrigger = _stateMachine.GetComponentInChildren<DetectionTrigger>();
        }

        public IState GetNextState()
        {
            if (_detectionTrigger.IsPlayerInTrigger && AimUtils.CanSeePlayer(_transform))
            {
                return _stateMachine.Attack;
            }
            return this;
        }

        public void Tick()
        {
        }
    }
}