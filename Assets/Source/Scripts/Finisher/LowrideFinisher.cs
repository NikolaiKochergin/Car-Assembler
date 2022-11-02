using System;
using UnityEngine;
using UnityEngine.Playables;

namespace CarAssembler
{
    public class LowrideFinisher : MonoBehaviour, IFinisher
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private Player _player;
        [SerializeField] private LowrideRace _lowrideRace;

        public IRace Race => _lowrideRace;
        
        private Action Ended;
        public void Show(Action ended)
        {
            Ended = ended;
            _player.transform.parent = transform;
            _playableDirector.Play();
        }
        
        public void SetEnded()
        {
            _player.transform.parent = null;
            _playableDirector.Stop();
            Ended?.Invoke();
        }
    }
}
