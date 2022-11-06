using System;
using UnityEngine;
using UnityEngine.Playables;

namespace CarAssembler
{
    public class FailFinisher : MonoBehaviour, IFinisher
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private Player _player;
        [SerializeField] private FailRace _failRace;

        public IRace Race => _failRace;

        public void Show(Action ended)
        {
            _player.transform.parent = transform;
            _playableDirector.Play();
        }
    }
}