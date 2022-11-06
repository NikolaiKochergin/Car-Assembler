using System;
using UnityEngine;

namespace CarAssembler
{
    public class LowrideRace : MonoBehaviour, IRace
    {
        [SerializeField] private Rival _rival;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private CountDown _countDown;

        private bool _isInRace;
        private float _playerEnergy;
        private float _rivalEnergy;
        private float _rivalTimer;

        private MainCameraContainer _mainCameraContainer;
        private Player _player;
        private UI _ui;

        public event Action RaceEnded;

        private void Awake()
        {
            Hide();
            _playerEnergy = 0;
            _rivalEnergy = 0;
        }

        private void Update()
        {
            if(_isInRace == false) return;
            
            if (Input.GetMouseButtonDown(0))
                _playerEnergy += 0.05f;


            if(_playerEnergy > 0)
                _playerEnergy -= 0.1f * Time.deltaTime;

            if (_rivalEnergy > 0)
                _rivalEnergy -= 0.1f * Time.deltaTime;

            _rivalTimer += Time.deltaTime;
            
            if (_rivalTimer > 0.5f)
            {
                _rivalEnergy += 0.1f;
                _rivalTimer = 0;
            }
            
            _player.AnimatorContainer.BlendLowride(_playerEnergy);
            
            _ui.RaceMenu.Lowride.PlayerSlider.SetValue(_playerEnergy);
            _ui.RaceMenu.Lowride.RivalSlider.SetValue(_rivalEnergy);
            
            if(_playerEnergy >= 1)
                StopRace();
        }

        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer)
        {
            _player = player;
            _ui = ui;
            _mainCameraContainer = mainCameraContainer;
        }

        public void StartRace()
        {
            _player.AnimatorContainer.Enable();
            _player.AnimatorContainer.ShowIdle();
            _mainCameraContainer.Follower.enabled = false;
            _mainCameraContainer.SetRacePosition();
            
            _player.transform.SetPositionAndRotation(_playerStartPoint.position, _playerStartPoint.rotation);
            
            _mainCameraContainer.transform.position = _player.transform.position;
            
            _ui.RaceMenu.Lowride.Show();
            _ui.RaceMenu.Lowride.PlayerSlider.SetValue(_playerEnergy);
            _ui.RaceMenu.Lowride.RivalSlider.SetValue(_rivalEnergy);
            _ui.RaceMenu.CountDownView.ShowCountDown();
            _countDown.ShowCountDown(() =>
            {
                _player.AnimatorContainer.ShowLowride();
                _isInRace = true;
            });
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void StopRace()
        {
            _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();
            _isInRace = false;
            
            _ui.RaceMenu.Lowride.Hide();
            
            RaceEnded?.Invoke();
        }
    }
}