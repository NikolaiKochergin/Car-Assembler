using TMPro;
using UnityEngine;

namespace CarAssembler
{
    public class UIPlayerResult : MonoBehaviour
    {
        [SerializeField] private TMP_Text _orderNumberText;
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _scoreText;

        public void Initialize(int orderNumber, string name, int score)
        {
            _orderNumberText.text = orderNumber.ToString("0");
            _nameText.text = name;
            _scoreText.text = score.ToString("0000");
        }
    }
}
