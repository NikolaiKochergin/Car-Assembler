using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.Playables;
using System;

namespace CarAssembler
{
    public class ComfortFinisher : MonoBehaviour, IFinisher
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private Player _player;
        [SerializeField] private GameObject _customer;

        public IRace Race { get; }

        public void Show(Action ended)
        {
            _player.animatorContainer.Enable();
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
    }
}
