using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace CarAssembler
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _enterKatScene;

        private IGameState _currentState;
        private Dictionary<Type, IGameState> _statesMap;

        public PlayerStateMachine PlayerStateMachine { get; private set; }
        public UI UI { get; private set; }
        public TaskChecker TaskChecker { get; private set; }
        public MainCameraContainer MainCameraContainer { get; private set; }

        private void Start()
        {
            PlayerStateMachine = FindObjectOfType<PlayerStateMachine>();
            UI = FindObjectOfType<UI>();
            TaskChecker = FindObjectOfType<TaskChecker>();
            MainCameraContainer = FindObjectOfType<MainCameraContainer>();
            
            InitStates();
            SetStateByDefault();
        }

        private void InitStates()
        {
            _statesMap = new Dictionary<Type, IGameState>
            {
                [typeof(InitialState)] = new InitialState(this),
                [typeof(KatSceneState)] = new KatSceneState(this, _enterKatScene),
                [typeof(PlayState)] = new PlayState(this),
                [typeof(FinisherState)] = new FinisherState(this),
                [typeof(RaceState)] = new RaceState(this),
                [typeof(EndLevelState)] = new EndLevelState(this)
            };
        }

        private void SetInitialState()
        {
            var state = GetState<InitialState>();
            SetState(state);
        }

        public void SetEnterKatSceneState()
        {
            var state = GetState<KatSceneState>();
            SetState(state);
        }

        public void SetPlayState()
        {
            var state = GetState<PlayState>();
            SetState(state);
        }

        public void SetFinisherState()
        {
            var state = GetState<FinisherState>();
            SetState(state);
        }

        [ContextMenu("RaceState")]
        public void SetRaceState()
        {
            var state = GetState<RaceState>();
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