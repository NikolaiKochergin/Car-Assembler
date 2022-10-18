using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private UISlider _slider;

        public void Initialize(Sprite icon, string taskText)
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
    }
}