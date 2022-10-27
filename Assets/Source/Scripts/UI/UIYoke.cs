using UnityEngine;

namespace CarAssembler
{
    public class UIYoke : MonoBehaviour
    {
        [SerializeField] private RectTransform _yokeArrow;
        [SerializeField] private float _maxAngle;
        [SerializeField] [Min(0.1f)] private float _duration = 1;
        [SerializeField] private AnimationCurve _inputCurve;
        [SerializeField] private AnimationCurve _arrowAnimationCurve;
        
        private bool _isRightArrowMove = true;

        private float _currentTime = 0.5f;

        public float InputValue { get; private set; }

        private void Update()
        {
            if (_isRightArrowMove)
                _currentTime += Time.deltaTime / _duration;
            else
                _currentTime -= Time.deltaTime / _duration;

            if (_currentTime >= 1 | _currentTime <= 0)
                _isRightArrowMove = !_isRightArrowMove;

            InputValue = _inputCurve.Evaluate(_currentTime);
            var arrowDirectionValue = _arrowAnimationCurve.Evaluate(_currentTime);

            _yokeArrow.localRotation = Quaternion.Euler(0, 0, _maxAngle * arrowDirectionValue);
        }
    }
}