using System;
using UnityEngine;
using UnityEngine.Playables;

namespace CarAssembler
{
    public class FlyFinisher : MonoBehaviour, IFinisher
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _customer;
        [SerializeField] private FlyRace _flyRace;

        public IRace Race => _flyRace;

        private Action Ended;
        
        public void Show(Action ended)
        {
            Ended = ended;
            _player.transform.parent = transform;
            _playableDirector.Play();
        }
        
        public void AddCustomerToPlayer()
        {
            _customer.transform.parent = _player.transform;
        }

        public void SetEnded()
        {
            _player.transform.parent = null;
            _playableDirector.Stop();
            Ended?.Invoke();
        }
    }
}
