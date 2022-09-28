using TMPro;
using UnityEngine;

namespace CarAssembler
{
    public class UIMoneyWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void ShowMoney(int value)
        {
            _text.text = value.ToString("0");
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
