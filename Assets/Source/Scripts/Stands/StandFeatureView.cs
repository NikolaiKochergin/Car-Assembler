using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class StandFeatureView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Color _weeknessColor;
        [SerializeField] private Color _powerColor;
        
        public FeatureType Type { get; private set; }

        private void Awake()
        {
            Hide();
        }

        public void Initialize(FeatureType featureType, Sprite icon, int value)
        {
            Type = featureType;
            _icon.sprite = icon;
            if (value > 0)
            {
                _text.text = "+" + value;
                _icon.color = _powerColor;
            }
            else if (value < 0)
            {
                _text.text = value.ToString();
                _icon.color = _weeknessColor;
            }
            else
            {
                _text.text = "0";
                _icon.color = Color.white;
            }
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
