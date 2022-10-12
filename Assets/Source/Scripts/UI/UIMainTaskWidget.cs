using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UIMainTaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _TaskImage;

        public void Initialize(Sprite taskIcon)
        {
            _TaskImage.sprite = taskIcon;
        }
    }
}