using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class YokeInput : MonoBehaviour
    {
        [SerializeField] private UIYoke _yoke;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(ShowValue);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowValue);
        }

        private void ShowValue()
        {
            Debug.Log(_yoke.InputValue);
        }
    }
}