using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Stand : MonoBehaviour
    {
        private const string DisableAnimation = nameof(DisableAnimation);
        private const string HighlightAnimation = nameof(HighlightAnimation);
        
        [SerializeField] private Collider _selfCollider;
        [SerializeField] private Animator _standAnimator;
        [SerializeField] private StandUI _standUI;
        [SerializeField] private Detail[] _detailPrefabs;

        private Detail _currentDetailPrefab;

        public StandUI UI => _standUI;
        public StandButton Button => _standUI.Button;
        
        public bool IsEnable { get; private set; }

        private void Start()
        {
            IsEnable = true;
            _currentDetailPrefab = _detailPrefabs[0];
            _standUI.Initialize(_currentDetailPrefab);
        }

        public void OnHighlight()
        {
            _standAnimator.enabled = true;
            _standAnimator.Play(HighlightAnimation);
            _standUI.Show();
        }

        public void OffHighlight()
        {
            _standAnimator.StopPlayback();
            _standAnimator.enabled = false;
            _standUI.Hide();
        }

        public void SetDetailByIndex(int index)
        {
            _currentDetailPrefab = _detailPrefabs[index];
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
            OffHighlight();
            _standAnimator.enabled = true;
            _standAnimator.Play(DisableAnimation);
            _standUI.gameObject.SetActive(false);
        }
    }
}