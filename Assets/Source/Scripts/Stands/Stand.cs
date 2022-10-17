using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Stand : MonoBehaviour
    {
        private const string DisableAnimation = nameof(DisableAnimation);
        private const string HighlightAnimation = nameof(HighlightAnimation);
        
        [SerializeField] private Collider _selfCollider;
        [SerializeField] private UIMoneyWidget _uiMoneyWidget;
        [SerializeField] private Animator _standAnimator;
        [SerializeField] private Detail[] _detailPrefabs;

        private Detail _currentDetailPrefab;
        
        public bool IsEnable { get; private set; }

        private void Start()
        {
            IsEnable = true;
            _currentDetailPrefab = _detailPrefabs[0];
        }

        public void OnHighlight()
        {
            _standAnimator.enabled = true;
            _standAnimator.Play(HighlightAnimation);
        }

        public void OffHighlight()
        {
            _standAnimator.StopPlayback();
            _standAnimator.enabled = false;
        }

        public Detail GetDetail()
        {
            Disable();
            return _currentDetailPrefab;
        }

        private void Disable()
        {
            IsEnable = false;
            _selfCollider.enabled = false;
            _uiMoneyWidget.Disable();
            OffHighlight();
            _standAnimator.enabled = true;
            _standAnimator.Play(DisableAnimation);
        }
    }
}