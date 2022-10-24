using System;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _brokenIconImage;
        [SerializeField] private Image _maxValueImage;
        [SerializeField] private Gradient _iconGradient;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        private FeatureType _featureType;

        public FeatureType Type => _featureType;
        
        public void Initialize(Sprite icon, Sprite brokenIcon, FeatureType featureType)
        {
            _iconImage.sprite = icon;
            _brokenIconImage.sprite = brokenIcon;
            _featureType = featureType;
        }

        public void SetValueBy(CarFeatures carFeatures)
        {
            switch (_featureType)
            {
                case FeatureType.Speed:
                    SetIconViewBy(carFeatures.Speed);
                    break;
                case FeatureType.FuelEconomy:
                    SetIconViewBy(carFeatures.FuelEconomy);
                    break;
                case FeatureType.Coolness:
                    SetIconViewBy(carFeatures.Coolness);
                    break;
                case FeatureType.Comfort:
                    SetIconViewBy(carFeatures.Comfort);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetIconViewBy(int value)
        {
            float normalizedValue = (value - _minValue) * 1f / (_maxValue - _minValue);

            if (value != 0)
            {
                Show();
            }
            
            if (value <= _minValue)
            {
                _iconImage.gameObject.SetActive(false);
                _brokenIconImage.gameObject.SetActive(true);
            }
            else if (value >= _maxValue)
            {
                _maxValueImage.gameObject.SetActive(true);
            }
            else
            {
                _iconImage.gameObject.SetActive(true);
                _brokenIconImage.gameObject.SetActive(false);
                _maxValueImage.gameObject.SetActive(false);
            }
            
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