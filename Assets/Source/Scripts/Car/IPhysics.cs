using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public interface IPhysics
    {
        public void MakePhysics(IReadOnlyList<Rigidbody> rigidbodies)
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                rigidbodies[i].isKinematic = false;
            }
        }
    }
}
