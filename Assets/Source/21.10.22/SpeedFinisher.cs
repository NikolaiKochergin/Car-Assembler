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

        public void Show(Action ended)
        {
            _customer.transform.parent = transform;
            _player.transform.parent = transform;
            //_playableDirector.SetReferenceValue("EmojiAngry 1", _test);
            _playableDirector.Play();
            //_playableDirector.
            Debug.Log("FAIL FINISHER");
            ended?.Invoke();
        }
    }
}
