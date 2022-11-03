using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class WheelSlots : MonoBehaviour
    {
        [SerializeField] private Transform[] _slots;

        public IReadOnlyList<Transform> Slots => _slots;
    }
}
