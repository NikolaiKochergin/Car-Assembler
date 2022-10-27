using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace CarAssembler
{
    public class SpeedFinisher : MonoBehaviour, IFinisher
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _customer;
        [SerializeField] private SpeedRace _speedRace;

        public IRace Race => _speedRace;

        private Action Ended;

        public void Show(Action ended)
        {
            Ended = ended;
            _player.transform.parent = transform;
            //_customer.transform.parent = _player.transform;
            //_playableDirector.SetReferenceValue("EmojiAngry 1", _test);
            _playableDirector.Play();
            //_playableDirector.
            Debug.Log("FAIL FINISHER");
            //ended?.Invoke();
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
