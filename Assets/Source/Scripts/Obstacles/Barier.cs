using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace CarAssembler
{
    public class Barier : ObstacleChecker
    {
        [SerializeField] [Range(0, 5)] private float _waitingTime;

        private Coroutine _timerCorutine;

        protected override void StartOpening()
        {
            _timerCorutine = StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(_waitingTime);

            Open();
        }

        private void Open()
        {
            Vector3 openValue = new Vector3(0f, 0f, 75f);
            float timeToOpen = 1f;

            _isOpen = true;
            transform.DORotate(openValue, timeToOpen).SetRelative();
        }
    }
}