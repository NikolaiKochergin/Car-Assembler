using UnityEngine;

namespace CarAssembler
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotType _slotType;

        public SlotType SlotType => _slotType;

        private void OnValidate()
        {
            gameObject.name = _slotType.ToString() + "Slot";
        }
    }
}
