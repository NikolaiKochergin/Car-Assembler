using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UISlider : MonoBehaviour
    {
        [SerializeField] private Image _filler;

        public void SetValue(float value)
        {
            _filler.fillAmount = value;
        }
    }
}
