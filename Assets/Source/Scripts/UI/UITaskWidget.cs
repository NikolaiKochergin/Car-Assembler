using System;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Gradient _iconGradient;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        private FeatureType _featureType;
        
        public void Initialize(Sprite icon, FeatureType featureType)
        {
            _iconImage.sprite = icon;
            _featureType = featureType;
        }

        public void SetValueBy(CarFeatures carFeatures)
        {
            switch (_featureType)
            {
                case FeatureType.Speed:
                    SetIconColorBy(carFeatures.Speed);
                    break;
                case FeatureType.FuelEconomy:
                    SetIconColorBy(carFeatures.FuelEconomy);
                    break;
                case FeatureType.Coolness:
                    SetIconColorBy(carFeatures.Coolness);
                    break;
                case FeatureType.Comfort:
                    SetIconColorBy(carFeatures.Comfort);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetIconColorBy(int value)
        {
            float normalizedValue = (value - _minValue) * 1f / (_maxValue - _minValue);

            _iconImage.color = _iconGradient.Evaluate(normalizedValue);
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