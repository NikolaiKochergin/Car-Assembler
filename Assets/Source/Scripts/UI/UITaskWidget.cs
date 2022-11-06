using System;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskWidget : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _brokenIconImage;
        [SerializeField] private Image _maxValueImage;
        [SerializeField] private Gradient _iconGradient;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        private FeatureType _featureType;
        private bool _isMainTask;
        private int _value;

        public FeatureType Type => _featureType;

        private void Awake()
        {
            OffHighlight();
        }

        public void Initialize(Sprite icon, Sprite brokenIcon, FeatureType featureType)
        {
            _iconImage.sprite = icon;
            _brokenIconImage.sprite = brokenIcon;
            _featureType = featureType;
        }

        public void MakeItMainTask()
        {
            _isMainTask = true;
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
                case FeatureType.Airplane:
                    SetIconViewBy(carFeatures.Airplane);
                    break;
                case FeatureType.Kindness:
                    SetIconViewBy(carFeatures.Angel);
                    break;
                case FeatureType.Boat:
                    SetIconViewBy(carFeatures.Boat);
                    break;
                case FeatureType.Angry:
                    SetIconViewBy(carFeatures.Devil);
                    break;
                case FeatureType.Elephant:
                    SetIconViewBy(carFeatures.Elephant);
                    break;
                case FeatureType.FireTrack:
                    SetIconViewBy(carFeatures.FireTrack);
                    break;
                case FeatureType.Fish:
                    SetIconViewBy(carFeatures.Fish);
                    break;
                case FeatureType.Offroad:
                    SetIconViewBy(carFeatures.Offroad);
                    break;
                case FeatureType.Spring:
                    SetIconViewBy(carFeatures.Spring);
                    break;
                case FeatureType.Power:
                    SetIconViewBy(carFeatures.Power);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetIconViewBy(int value)
        {
            _value = value;
            
            float normalizedValue = (value - _minValue) * 1f / (_maxValue - _minValue);
            
            if(value == 0 && _isMainTask == false)
                Hide();
            else
                Show();

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

        public void OnHighlight()
        {
            _animator.enabled = true;
        }

        public void OffHighlight()
        {
            _animator.enabled = false;
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