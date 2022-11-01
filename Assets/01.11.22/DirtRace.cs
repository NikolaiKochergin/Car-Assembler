using System;
using System.Collections;
using System.Collections.Generic;
using CarAssembler;
using UnityEngine;

namespace CarAssembler
{
    public class DirtRace : MonoBehaviour, IRace
    {
        public event Action RaceEnded;
        public void Initialize(Player player, UI ui, MainCameraContainer mainCameraContainer)
        {
            
        }

        public void StartRace()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}
