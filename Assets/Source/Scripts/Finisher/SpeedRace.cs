using System;
using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class SpeedRace : MonoBehaviour, IRace
    {
        [SerializeField] private Player _player;
        [SerializeField] private SplineComputer _spline;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Rival _rival;
        [SerializeField] private CountDown _countDown;
        [SerializeField] [Min(0)] private float _startSpeed = 6;

        private void Awake()
        {
            Hide();
        }

        public event Action RaceEnded;

        [ContextMenu("StartRace")]
        public void StartRace()
        {
            _player.PlayerMover.SetFollowSpeed(_startSpeed);
            _player.PlayerMover.SplineFollower.spline = _spline;
            _player.PlayerMover.SplineFollower.SetPercent(0);
            _player.transform.SetPositionAndRotation(_playerStartPoint.position,_playerStartPoint.rotation);

            _countDown.ShowCountDown(() =>
            {
                _player.PlayerMover.StartMove();
                _player.StartRotationWheels();
                _rival.StartMove();
                _rival.StartRotationWheels();
            });
        }

        public void SetRivalSpeedMultiplier(float value)
        {
            _rival.SetSpeedMultiplier(value);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}