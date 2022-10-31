using System;

namespace CarAssembler
{
    public interface IRace
    {
        public event Action RaceEnded;

        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer);
        public void StartRace();
        public void Show();
        public void Hide();
    }
}