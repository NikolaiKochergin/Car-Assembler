using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _fillerTrue;
        [SerializeField] private Image _fillerFalse;

        public void Initialize(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void MarkCompleted(bool isCombleted)
        {
            _fillerTrue.enabled = isCombleted;
            _fillerFalse.enabled = !isCombleted;
        }
    }
}