using UnityEngine;
using UnityEngine.UI;

public class UIMainTaskWidget : MonoBehaviour
{
    [SerializeField] private Image _TaskImage;

    public void Initialize(Sprite taskIcon)
    {
        _TaskImage.sprite = taskIcon;
    }
}