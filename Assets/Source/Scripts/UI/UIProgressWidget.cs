using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UIProgressWidget : MonoBehaviour
    {
        [SerializeField] private Image _filler;
        [SerializeField] private Image _nextLevelFiller;
        [SerializeField] private TMP_Text _currentLevelText;
        [SerializeField] private TMP_Text _nextLevelText;

        private Player _player;

        public void Initialize(int currentLevel, Player player)
        {
            _currentLevelText.text = currentLevel.ToString();
            _nextLevelText.text = (currentLevel + 1).ToString();
            _player = player;
        }

        private void Update()
        {
            var levelProgress = _player.PlayerMover.GetLevelProgress();
            SetValue(levelProgress);
        }

        private void SetValue(float value)
        {
            _filler.fillAmount = value;
            if (_filler.fillAmount == 1)
                _nextLevelFiller.gameObject.SetActive(true);
            else
                _nextLevelFiller.gameObject.SetActive(false);
        }
    }
}