using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class WheelRight : Wheel
    {
        public override void Update()
        {
            transform.Rotate(Vector3.left * Speed * Time.deltaTime);
        }
    }
}
