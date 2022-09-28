using System;
using UnityEngine;

namespace CarAssembler
{
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

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (player)
                _meshRenderer.sharedMaterial = _highlightMaterial;
        }

        private void OnTriggerExit(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (player)
                _meshRenderer.sharedMaterial = _commonMaterial;
        }

        public Detail GetDetail()
        {
            _meshRenderer.sharedMaterial = _commonMaterial;
            
            _selfCollider.enabled = false;
            Detail tempDetail = _detail;
            _detail = null;
            tempDetail.Hide();
            return tempDetail;
        }
    }
}