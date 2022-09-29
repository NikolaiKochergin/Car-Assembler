using System;
using UnityEngine;

namespace CarAssembler
{
    public class CollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var factoryMachine = other.GetComponent<FactoryMachine>();
            var obstacle = other.GetComponent<Obstacle>();
            
            if(factoryMachine)
                FactoryMachineTaken?.Invoke(factoryMachine);
            
            if(obstacle)
                ObstacleTaken?.Invoke();
                
        }

        private void OnTriggerExit(Collider other)
        {
            var factotyMachine = other.GetComponent<FactoryMachine>();
            
            if(factotyMachine)
                FactoryMachineLost?.Invoke(factotyMachine);
        }

        public event Action<FactoryMachine> FactoryMachineTaken;
        public event Action<FactoryMachine> FactoryMachineLost;
        public event Action ObstacleTaken;
    }
}
