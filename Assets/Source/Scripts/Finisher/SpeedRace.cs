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

        private void Awake()
        {
            Hide();
        }

        public event Action RaceEnded;

        [ContextMenu("StartRace")]
        public void StartRace()
        {
            _player.transform.position = _playerStartPoint.position;
            _player.transform.rotation = _playerStartPoint.rotation;

            _player.PlayerMover.SplineFollower.spline = _spline;
            _player.PlayerMover.SplineFollower.SetPercent(0);
            _player.PlayerMover.StartMove();
            _rival.StartMove();
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