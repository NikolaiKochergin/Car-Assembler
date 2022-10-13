using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskProgressWidget : MonoBehaviour
    {
        [SerializeField] private Image _filler;

        private Player _player;

        private void OnEnable()
        {
            if (_player)
                _player.CarPriceChanged += OnCarPriceChanged;
        }

        private void OnDisable()
        {
            if (_player)
                _player.CarPriceChanged -= OnCarPriceChanged;
        }

        public void Initialize(Player player)
        {
            _player = player;
            OnCarPriceChanged(_player.CarPrice);
        }

        private void OnCarPriceChanged(int value)
        {
            var normalizedValue = value * 1f / 100f;
            SetValue(normalizedValue);
        }

        private void SetValue(float value)
        {
            _filler.fillAmount = value;
        }
    }
}