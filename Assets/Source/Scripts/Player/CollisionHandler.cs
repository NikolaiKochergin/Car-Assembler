using System;
using UnityEngine;

namespace CarAssembler
{
    public class CollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var factoryMachine = other.GetComponent<Stand>();
            var obstacle = other.GetComponent<Obstacle>();
            
            if(factoryMachine)
                StandTaken?.Invoke(factoryMachine);
            
            if(obstacle)
                ObstacleTaken?.Invoke(obstacle);
        }

        private void OnTriggerExit(Collider other)
        {
            var factoryMachine = other.GetComponent<Stand>();
            
            if(factoryMachine)
                StandLost?.Invoke(factoryMachine);
        }

        public event Action<Stand> StandTaken;
        public event Action<Stand> StandLost;
        public event Action<Obstacle> ObstacleTaken;
    }
}
