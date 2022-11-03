using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class WheelsList : MonoBehaviour
    {
        [SerializeField] private Transform[] _wheels;

        public IReadOnlyList<Transform> Wheels => _wheels;
    }
}
