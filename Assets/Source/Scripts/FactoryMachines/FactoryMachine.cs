using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class FactoryMachine : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _highlightMaterial;
        [SerializeField] private Material _commonMaterial;
        [SerializeField] private Collider _selfCollider;
        [SerializeField] private Detail _detail;

        public Detail Detail => _detail;

        public void BuffDetailPrice(int value)
        {
            Debug.Log("Тут стоит подумать, как лучше менять цену деталей.");

            _detail.SetPrice(_detail.Price * value);
        }

        public void OnHighlight()
        {
            _meshRenderer.sharedMaterial = _highlightMaterial;
        }

        public void OffHighlight()
        {
            _meshRenderer.sharedMaterial = _commonMaterial;
        }

        public Detail GetDetail()
        {
            OffHighlight();
            
            _selfCollider.enabled = false;
            var tempDetail = _detail;
            _detail = null;
            tempDetail.Hide();
            return tempDetail;
        }
    }
}