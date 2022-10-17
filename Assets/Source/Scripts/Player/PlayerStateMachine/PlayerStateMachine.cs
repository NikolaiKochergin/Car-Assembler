using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private Player _player;
        private IPlayerState _currentState;

        private Dictionary<Type, IPlayerState> _statesMap;

        public Player Player => _player;

        private void Awake()
        {
            InitStates();
        }

        private void Start()
        {
            SetStateByDefault();
        }

        private void Update()
        {
            _currentState.Update();
        }

        private void OnEnable()
        {
            _player.PlayerMover.EndLevelReached += SetNonControlledState;
        }

        private void OnDisable()
        {
            _player.PlayerMover.EndLevelReached -= SetNonControlledState;
        }

        private void InitStates()
        {
            _statesMap = new Dictionary<Type, IPlayerState>
            {
                [typeof(IdleState)] = new IdleState(this),
                [typeof(MoveState)] = new MoveState(this),
                [typeof(PartPickingState)] = new PartPickingState(this),
                [typeof(NonControlledState)] = new NonControlledState(_player)
            };
        }

        public void SetIdleState()
        {
            var state = GetState<IdleState>();
            SetState(state);
        }

        public void SetMoveState()
        {
            var state = GetState<MoveState>();
            SetState(state);
        }

        public void SetPartPickingState()
        {
            var state = GetState<PartPickingState>();
            SetState(state);
        }

        public void SetNonControlledState()
        {
            var state = GetState<NonControlledState>();
            SetState(state);
        }

        private void SetStateByDefault()
        {
            SetNonControlledState();
        }

        private void SetState(IPlayerState newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private IPlayerState GetState<T>() where T : IPlayerState
        {
            var type = typeof(T);
            return _statesMap[type];
        }
    }
}