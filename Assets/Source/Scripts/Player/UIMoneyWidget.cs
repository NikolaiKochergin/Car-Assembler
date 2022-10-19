using TMPro;
using UnityEngine;

namespace CarAssembler
{
    public class UIMoneyWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetMoneyText(int value)
        {
            string valueText;

            if (value >= 1000)
                valueText = (value / 1000).ToString("0.0") + "K";
            else
                valueText = value.ToString("0");

            _text.text = "$ " + valueText;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}