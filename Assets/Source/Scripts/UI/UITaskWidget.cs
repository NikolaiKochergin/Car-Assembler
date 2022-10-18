using System;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private UISlider _slider;

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
                    _slider.SetValue(carFeatures.Speed);
                    break;
                case FeatureType.FuelEconomy:
                    _slider.SetValue(carFeatures.FuelEconomy);
                    break;
                case FeatureType.Power:
                    _slider.SetValue(carFeatures.Power);
                    break;
                case FeatureType.Coolness:
                    _slider.SetValue(carFeatures.Coolness);
                    break;
                case FeatureType.Comfort:
                    _slider.SetValue(carFeatures.Comfort);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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