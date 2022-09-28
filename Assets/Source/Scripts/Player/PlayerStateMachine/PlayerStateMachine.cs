using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private Dictionary<Type, IPlayerState> _statesMap;
        private IPlayerState _currentState;

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

        private void InitStates()
        {
            _statesMap = new Dictionary<Type, IPlayerState>
            {
                [typeof(IdleState)] = new IdleState(),
                [typeof(MoveState)] = new MoveState(),
                [typeof(PartPickingState)] = new PartPickingState()
            };
        }
        
        private void SetIdleState()
        {
            var state = GetState<IdleState>();
            SetState(state);
        }

        private void SetMoveState()
        {
            var state = GetState<MoveState>();
            SetState(state);
        }

        private void SetPartPickingState()
        {
            var state = GetState<PartPickingState>();
            SetState(state);
        }
        
        private void SetStateByDefault()
        {
            SetIdleState();
        }
    
        private void SetState(IPlayerState newState)
        {
            if(_currentState != null)
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
