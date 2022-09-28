using System;
using System.Collections;
using UnityEngine;

namespace CarAssembler
{
    public class TakingDetailTimer : MonoBehaviour
    {
        [SerializeField] private UITimerWidget _uiTimerWidget;
        [SerializeField] [Min(0)] private float _duration;

        private Coroutine _timerCoroutine;

        public void StartTimer(Action callback)
        {
            StopTimer();
            _timerCoroutine = StartCoroutine(TimerCoroutine(callback));
        }

        public void StopTimer()
        {
            _uiTimerWidget.Disable();
            if(_timerCoroutine != null)
                StopCoroutine(_timerCoroutine);
        }
        
        private IEnumerator TimerCoroutine(Action callback)
        {
            _uiTimerWidget.Enable();
            for (float i = 0; i < 1; i += Time.deltaTime / _duration)
            {
                _uiTimerWidget.ShowTimer(i);

                yield return null;
            }
            _uiTimerWidget.Disable();
            callback?.Invoke();
        }
    }
}