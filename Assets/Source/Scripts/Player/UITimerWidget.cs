using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITimerWidget : MonoBehaviour
    {
        [SerializeField] private Image _fillerImage;

        private void Start()
        {
            Disable();
        }

        public void ShowTimer(float value)
        {
            _fillerImage.fillAmount = value;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}