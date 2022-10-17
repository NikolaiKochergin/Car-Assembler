using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CarAssembler
{
    public class InitialState : IGameState
    {
        private readonly PlayerStateMachine _playerStateMachine;
        private readonly UI _ui;
        private readonly string LevelSetupPath = "LevelSetup/";

        public InitialState(PlayerStateMachine playerStateMachine, UI ui)
        {
            _playerStateMachine = playerStateMachine;
            _ui = ui;
        }

        public void Enter()
        {
            var levelSetup = GetLevelSetup();
            _playerStateMachine.Player.Initialize(levelSetup.Car);
            _playerStateMachine.SetNonControlledState();
            _ui.MainMenu.Show();
        }

        public void Exit()
        {
            _ui.MainMenu.Hide();
        }

        private LevelSetup GetLevelSetup()
        {
            var levelSetups = Resources.LoadAll<LevelSetup>(LevelSetupPath);

            if (levelSetups.Length == 0)
                throw new ArgumentOutOfRangeException(
                    $"LevelSetup not created by path Assets/Resources/{LevelSetupPath}");

            var index = SceneManager.GetActiveScene().buildIndex - 1;
            index = Mathf.Clamp(index, 0, levelSetups.Length - 1);

            return levelSetups[index];
        }
    }
}