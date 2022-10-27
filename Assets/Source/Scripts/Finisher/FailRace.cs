using System;
using UnityEngine;

namespace CarAssembler
{
    public class FailRace : MonoBehaviour, IRace
    {
        public event Action RaceEnded;
        public void StartRace()
        {
            RaceEnded?.Invoke();
        }
    }
}
