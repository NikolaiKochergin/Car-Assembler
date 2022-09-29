using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine _playerStateMachine;
        [SerializeField] private UI _uI;
        private IGameState _currentState;

        private Dictionary<Type, IGameState> _statesMap;

        private void Awake()
        {
            InitStates();
        }

        private void Start()
        {
            SetStateByDefault();
        }

        private void OnEnable()
        {
            _uI.MainMenu.StartButton.ButtonPressedDown += SetPlayState;
        }

        private void OnDisable()
        {
            _uI.MainMenu.StartButton.ButtonPressedDown -= SetPlayState;
        }

        private void InitStates()
        {
            _statesMap = new Dictionary<Type, IGameState>
            {
                [typeof(InitialState)] = new InitialState(_playerStateMachine, _uI),
                [typeof(PlayState)] = new PlayState(_playerStateMachine, _uI),
                [typeof(FinisherState)] = new FinisherState(_playerStateMachine, _uI),
                [typeof(EndLevelState)] = new EndLevelState(_playerStateMachine, _uI)
            };
        }

        private void SetInitialState()
        {
            var state = GetState<InitialState>();
            SetState(state);
        }

        private void SetPlayState()
        {
            var state = GetState<PlayState>();
            SetState(state);
        }

        private void SetFinisherState()
        {
            var state = GetState<FinisherState>();
            SetState(state);
        }

        private void SetEndLevelState()
        {
            var state = GetState<EndLevelState>();
            SetState(state);
        }

        private void SetStateByDefault()
        {
            SetInitialState();
        }

        private void SetState(IGameState newState)
        {
            if (_currentState != null)
                _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private IGameState GetState<T>() where T : IGameState
        {
            var type = typeof(T);
            return _statesMap[type];
        }
    }
}