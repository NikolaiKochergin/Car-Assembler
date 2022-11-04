using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UISlider : MonoBehaviour
    {
        [SerializeField] private Image _filler;
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        public Image Filler => _filler;
        public int MinValue => _minValue;
        public int MaxValue => _maxValue;

        public void SetValue(float value)
        {
            _filler.fillAmount = (value - _minValue) * 1f / (_maxValue - _minValue);
            Debug.Log(_filler.fillAmount + " - _filler.fillAmount");
        }
    }
}
