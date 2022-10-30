using System;
using System.Collections;
using UnityEngine;

namespace CarAssembler
{
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private float _duration;

        public void ShowCountDown(Action ended)
        {
            StartCoroutine(CountDownShowing(ended));
        }

        private IEnumerator CountDownShowing(Action ended)
        {
            yield return new WaitForSeconds(_duration);
            
            ended?.Invoke();
        }
    }
}
