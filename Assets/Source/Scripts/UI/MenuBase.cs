using UnityEngine;

namespace CarAssembler
{
    public class MenuBase : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        public RectTransform RectTransform => _rectTransform;

        private void Awake()
        {
            Hide();
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