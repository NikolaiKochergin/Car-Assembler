using System.Collections;
using System.Collections.Generic;
using CarAssembler;
using UnityEngine;

namespace CarAssembler
{
    public class WheelLeft : Wheel
    {
        public override void Update()
        {
            transform.Rotate(Vector3.right * Speed * Time.deltaTime);
        }
    }
}