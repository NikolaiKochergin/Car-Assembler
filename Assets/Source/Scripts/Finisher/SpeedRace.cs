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


        public event Action RaceEnded;
        
        [ContextMenu("StartRace")]
        public void StartRace()
        {
            _player.transform.position = _playerStartPoint.position;
            _player.transform.rotation = _playerStartPoint.rotation;

            _player.PlayerMover.SplineFollower.spline = _spline;
            _player.PlayerMover.SplineFollower.SetPercent(0);
            _player.PlayerMover.StartMove();

        }
    }
}