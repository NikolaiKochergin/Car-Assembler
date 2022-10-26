using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Stand : MonoBehaviour, IDisableable
    {
        private const string DisableAnimation = nameof(DisableAnimation);
        private const string HighlightAnimation = nameof(HighlightAnimation);

        [SerializeField] private Collider _selfCollider;
        [SerializeField] private Animator _standAnimator;
        [SerializeField] private StandUI _standUI;
        [SerializeField] private Detail[] _detailPrefabs;
        [SerializeField] private List<MonoBehaviour> _toDisables;

        private List<IDisableable> _toDisableInterfaces;

        public StandUI UI => _standUI;
        public StandButton Button => _standUI.Button;
        public Detail Detail { get; private set; }

        public bool IsEnable { get; private set; }

        private void Start()
        {
            _toDisableInterfaces = new List<IDisableable>();
            foreach (var disableable in _toDisables) _toDisableInterfaces.Add((IDisableable) disableable);

            IsEnable = true;
            Detail = _detailPrefabs[0];
            _standUI.Initialize(Detail);
        }

        private void OnValidate()
        {
            foreach (var disableable in
                     _toDisables.Where(disableable => disableable && disableable is not IDisableable))
            {
                Debug.LogError(nameof(disableable) + " needs to implement " + nameof(IDisableable));
                _toDisables.Remove(disableable);
            }
        }

        public void Disable()
        {
            if(IsEnable == false) return;
            
            IsEnable = false;
            _selfCollider.enabled = false;
            OffHighlight();
            _standAnimator.enabled = true;
            _standAnimator.Play(DisableAnimation);
            _standUI.gameObject.SetActive(false);
            DisablePairStands();
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
            Detail = _detailPrefabs[index];
        }

        public Detail GetDetail()
        {
            Disable();
            return Detail;
        }

        private void DisablePairStands()
        {
            foreach (var disableable in _toDisableInterfaces)
                disableable.Disable();
        }
    }
}