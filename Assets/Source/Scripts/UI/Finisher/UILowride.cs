using UnityEngine;

namespace CarAssembler
{
    public class UILowride : MonoBehaviour
    {
        [SerializeField] private UISlider _playerEnergySlider;
        [SerializeField] private UISlider _rivalEnergySlider;

        public UISlider PlayerSlider => _playerEnergySlider;
        public UISlider RivalSlider => _rivalEnergySlider;

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
