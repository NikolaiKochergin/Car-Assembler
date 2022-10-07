using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _fillerTrue;
        [SerializeField] private Image _fillerFalse;
        [SerializeField] private Image _checkImage;
        [SerializeField] private Image _crossImage;
        [SerializeField] private Image _alfaImage;

        public void Initialize(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void ShowFalse()
        {
            StartCoroutine(CrossShowing());
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void MarkCompleted(bool isCombleted)
        {
            _fillerTrue.enabled = !isCombleted;
            _fillerFalse.enabled = isCombleted;
            _checkImage.enabled = isCombleted;
            _alfaImage.enabled = isCombleted;
        }

        private IEnumerator CrossShowing()
        {
            for (float i = 1; i > 0; i -= Time.deltaTime)
            {
                _crossImage.color = new Color(_crossImage.color.r, _crossImage.color.g, _crossImage.color.b, i);

                yield return null;
            }

            _crossImage.color = new Color(_crossImage.color.r, _crossImage.color.g, _crossImage.color.b, 0);
        }
    }
}