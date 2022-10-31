using System;
using UnityEngine;

namespace CarAssembler
{
    public class FailRace : MonoBehaviour, IRace
    {
        private void Awake()
        {
            Hide();
        }

        public event Action RaceEnded;

        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer)
        {
        }

        public void StartRace()
        {
            RaceEnded?.Invoke();
        }

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