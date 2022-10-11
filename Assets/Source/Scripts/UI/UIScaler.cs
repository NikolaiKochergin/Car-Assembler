using UnityEngine;

namespace CarAssembler
{
    public class UIScaler : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        private void Update()
        {
            transform.localScale = _targetTransform.localScale;
        }
    }
}