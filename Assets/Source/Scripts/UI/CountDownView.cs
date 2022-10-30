using System.Collections;
using TMPro;
using UnityEngine;

namespace CarAssembler
{
    public class CountDownView : MonoBehaviour
    {
        private const string Appear = nameof(Appear);

        [SerializeField] private TMP_Text _text;
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void ShowCountDown()
        {
            gameObject.SetActive(true);
            StartCoroutine(CountDownShowing());
        }

        private IEnumerator CountDownShowing()
        {
            _text.text = "3";
            yield return new WaitForSeconds(1f);
            _text.text = "2";
            _animator.SetTrigger(Appear);
            yield return new WaitForSeconds(1f);
            _text.text = "1";
            _animator.SetTrigger(Appear);
            yield return new WaitForSeconds(1f);
            _text.text = "Go";
            _animator.SetTrigger(Appear);
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}