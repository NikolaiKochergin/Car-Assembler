using System;
using System.Collections;
using UnityEngine;

namespace CarAssembler
{
    public class SomeFinisher : MonoBehaviour, IFinisher
    {
        [SerializeField] private float _duration;

        public IRace Race { get; }

        public void Show(Action ended)
        {
            StartCoroutine(FinisherShowing(ended));
        }

        private IEnumerator FinisherShowing(Action ended)
        {
            Debug.Log("Финишер начинается");

            for (float t = 0; t < 1; t += Time.deltaTime / _duration)
            {
                Debug.Log("Финишер проигрывается");

                yield return null;
            }

            Debug.Log("Финишер закончен");
            ended?.Invoke();
        }
    }
}