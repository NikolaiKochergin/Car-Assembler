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
        [SerializeField] private Detail _detailPrefab;
        [SerializeField] private DetailFeatures _detailFeatures;

        public DetailFeatures DetailFeatures => _detailFeatures;
        public bool IsEnable { get; private set; }

        private void Start()
        {
            IsEnable = true;
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
            return _detailPrefab;
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