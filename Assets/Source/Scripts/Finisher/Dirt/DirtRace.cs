using System;
using System.Collections;
using Dreamteck.Splines;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CarAssembler
{
    public class DirtRace : MonoBehaviour, IRace
    {
        [SerializeField] private SplineComputer _spline;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private Rival _rival;
        [SerializeField] private CountDown _countDown;
        [SerializeField] [Min(0)] private float _startSpeed = 6;
        [SerializeField] private AnimationCurve _changeSpeedCurve;
        [SerializeField] [Min(0)] private float _changeSpeedDuration = 1;
        [SerializeField] private ParticleContainer _rivalDirtVFX;
        [SerializeField] private Animator _rivalAnimator;

        private Coroutine _changeSpeedCoroutine;
        private Coroutine _rivalChangeSpeedCoroutine;

        private float _defaultSpeed;
        private bool _isOnQuickTimeEvent;
        private float _timer = 0;
        
        private MainCameraContainer _mainCameraContainer;
        private Player _player;
        private float _speedMultiplier;
        private UI _ui;

        private void Awake()
        {
            Hide();
            _defaultSpeed = _startSpeed;
            _speedMultiplier = 1;
        }

        private void Update()
        {
            if (_isOnQuickTimeEvent == false) return;

            if (Input.GetMouseButtonDown(0)) 
                _changeSpeedCoroutine ??= StartCoroutine(ChangeSpeedCoroutine());
            
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _timer = Random.Range(_changeSpeedDuration * 1.3f, _changeSpeedDuration * 1.8f);

                if (_rivalChangeSpeedCoroutine != null)
                {
                    StopCoroutine(_rivalChangeSpeedCoroutine);
                    _rivalChangeSpeedCoroutine = null;
                }
                
                _rivalChangeSpeedCoroutine = StartCoroutine(RivalChangeSpeedCoroutine());
            }
        }

        public event Action RaceEnded;

        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer)
        {
            _player = player;
            _ui = ui;
            _mainCameraContainer = mainCameraContainer;

            _player.QuickTimeEventTaken += OnQuickTimeEventTaken;
            _player.QuickTimeEventEnded += OnQuickTimeEventEnded;
        }

        public void StartRace()
        {
            _player.AnimatorContainer.Enable();
            _player.AnimatorContainer.ShowIdle();
            _player.PlayerMover.SplineFollower.spline = _spline;
            _player.PlayerMover.SplineFollower.SetPercent(0);
            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
            _player.transform.SetPositionAndRotation(_playerStartPoint.position, _playerStartPoint.rotation);
            
            _mainCameraContainer.transform.position = _player.transform.position;
            _mainCameraContainer.SetRacePosition();

            _ui.RaceMenu.CountDownView.ShowCountDown();
            _countDown.ShowCountDown(() =>
            {
                _player.PlayerMover.StartMove();

                _player.AnimatorContainer.ShowDefaultDirtRace();
                _player.ParticleContainer.PlayDirtFall();
                _player.StartRotationWheels();
                _rival.StartMove();
                _rival.StartRotationWheels();
                _rivalDirtVFX.PlayDirtFall();
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

        private void OnQuickTimeEventTaken(QuickTimeEvent quickTimeEvent)
        {
            _player.AnimatorContainer.ShowDirtRace();
            _isOnQuickTimeEvent = true;
            
            _ui.RaceMenu.TapMessage.Show();

            _speedMultiplier = 1;

            _player.PlayerMover.SetFollowSpeed(_defaultSpeed * 0.5f);
            _rival.SetSpeedMultiplier(0.5f);
            _rivalAnimator.enabled = true;
        }

        private void OnQuickTimeEventEnded()
        {
            _player.AnimatorContainer.ShowDefaultDirtRace();
            _isOnQuickTimeEvent = false;

            if (_changeSpeedCoroutine != null)
            {
                StopCoroutine(_changeSpeedCoroutine);
                _changeSpeedCoroutine = null;
            }
            
            if (_rivalChangeSpeedCoroutine != null)
            {
                StopCoroutine(_rivalChangeSpeedCoroutine);
                _rivalChangeSpeedCoroutine = null;
            }
            
            _ui.RaceMenu.TapMessage.Hide();

            _player.PlayerMover.SetFollowSpeed(_defaultSpeed);
            _rival.SetSpeedMultiplier(1);
            _rivalAnimator.enabled = false;

            if (_player.Car.CurrentWheels != null) 
                _player.ChangeRotationWheels(_player.PlayerMover.MoveSpeed);

        }

        //Used in Race Spline Computer trigger
        public void StopRace()
        {
            _player.PlayerMover.StopMove();
            _player.AnimatorContainer.ShowIdle();
            _player.ParticleContainer.StopDirtFall();
            _player.StopRotationWheels();

            _player.QuickTimeEventTaken -= OnQuickTimeEventTaken;
            _player.QuickTimeEventEnded -= OnQuickTimeEventEnded;

            _mainCameraContainer.CameraAnimator.ShowEndLevelAnimation();

            Invoke(nameof(SetEndRace), 1.5f);
        }

        private void SetEndRace()
        {
            RaceEnded?.Invoke();
        }

        private IEnumerator ChangeSpeedCoroutine()
        {
            for (float t = 0; t < 1; t += Time.deltaTime / _changeSpeedDuration)
            {
                _player.PlayerMover.SetFollowSpeed(_defaultSpeed * _changeSpeedCurve.Evaluate(t));

                yield return null;
            }

            _changeSpeedCoroutine = null;
        }

        private IEnumerator RivalChangeSpeedCoroutine()
        {
            for (float t = 0; t < 1; t += Time.deltaTime / _changeSpeedDuration)
            {
                _rival.SetSpeedMultiplier(_changeSpeedCurve.Evaluate(t));

                yield return null;
            }

            _rivalChangeSpeedCoroutine = null;
        }
    }
}