using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace CarAssembler
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine _playerStateMachine;
        [SerializeField] private UI _uI;
        [SerializeField] private PlayableDirector _enterKatScene;
        [SerializeField] private TaskChecker _taskChecker;
        [SerializeField] private MainCameraContainer _mainCameraContainer;

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
            _uI.MainMenu.StartButton.ButtonPressedDown += SetEnterKatSceneState;
            _playerStateMachine.Player.PlayerMover.EndLevelReached += SetFinisherState;
        }

        private void OnDisable()
        {
            _uI.MainMenu.StartButton.ButtonPressedDown -= SetEnterKatSceneState;
            _playerStateMachine.Player.PlayerMover.EndLevelReached -= SetFinisherState;
        }

        private void InitStates()
        {
            _statesMap = new Dictionary<Type, IGameState>
            {
                [typeof(InitialState)] = new InitialState(_playerStateMachine, _uI),
                [typeof(KatSceneState)] = new KatSceneState(_enterKatScene, _uI),
                [typeof(PlayState)] = new PlayState(_playerStateMachine, _uI),
                [typeof(FinisherState)] = new FinisherState(this, _playerStateMachine, _uI, _taskChecker, _mainCameraContainer),
                [typeof(EndLevelState)] = new EndLevelState(_playerStateMachine, _uI)
            };
        }

        private void SetInitialState()
        {
            var state = GetState<InitialState>();
            SetState(state);
        }

        private void SetEnterKatSceneState()
        {
            var state = GetState<KatSceneState>();
            SetState(state);
        }

        public void SetPlayState()
        {
            var state = GetState<PlayState>();
            SetState(state);
        }

        private void SetFinisherState()
        {
            var state = GetState<FinisherState>();
            SetState(state);
        }

        public void SetEndLevelState()
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