using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UICloudTaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Color _iconColor;
        [SerializeField] private TMP_Text _taskText;

        public void Initialize(Sprite icon, string taskText)
        {
            _iconImage.sprite = icon;
            _iconImage.color = _iconColor;
            _taskText.text = taskText;
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
