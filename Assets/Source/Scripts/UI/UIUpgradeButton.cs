using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIUpgradeButton : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private TMP_Text _headerText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _headerName;
    [SerializeField] [Min(0)] private int _price;

    private void OnValidate()
    {
        _iconImage.sprite = _icon;
        _headerText.text = _headerName;
        _priceText.text = "$ " + _price;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(_headerName);
    }
}