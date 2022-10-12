using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Stand : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _highlightMaterial;
        [SerializeField] private Material _commonMaterial;
        [SerializeField] private Collider _selfCollider;
        [SerializeField] private UIMoneyWidget _uiMoneyWidget;
        [SerializeField] private Animator _standAnimator;
        [SerializeField] private Detail _detailPrefab;
        [SerializeField] private Stand[] _pairStands;

        public bool IsEnable { get; private set; }

        private void Start()
        {
            _uiMoneyWidget.SetMoneyText(_detailPrefab.Price);
            IsEnable = true;
        }

        public void OnHighlight()
        {
            _meshRenderer.material = _highlightMaterial;
        }

        public void OffHighlight()
        {
            _meshRenderer.material = _commonMaterial;
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
            DisablePairStands();
        }

        private void DisablePairStands()
        {
            foreach (var stand in _pairStands)
                if (stand.IsEnable)
                    stand.Disable();
        }
    }
}