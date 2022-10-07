using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class UITaskProgressWidget : MonoBehaviour
    {
        [SerializeField] private Image _filler;

        private Player _player;

        // private void Update()
        // {
        //     var levelProgress = _player.PlayerMover.GetLevelProgress();
        //     SetValue(levelProgress);
        // }

        public void Initialize(Player player)
        {
            _player = player;
        }

        private void SetValue(float value)
        {
            _filler.fillAmount = value;
        }
    }
}