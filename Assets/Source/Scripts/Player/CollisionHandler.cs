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
            var barrier = other.GetComponent<Barrier>();
            var yokeEvent = other.GetComponent<YokeEvent>();
            
            if(factoryMachine)
                StandTaken?.Invoke(factoryMachine);
            
            if(obstacle)
                ObstacleTaken?.Invoke(obstacle);
            
            if(barrier)
                BarrierTaken?.Invoke(barrier);
            
            if(yokeEvent)
                YokeEventTaken?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            var factoryMachine = other.GetComponent<Stand>();
            var yokeEvent = other.GetComponent<YokeEvent>();
            
            if(factoryMachine)
                StandLost?.Invoke(factoryMachine);
            
            if(yokeEvent)
                YokeEventEnded?.Invoke();
        }

        public event Action<Stand> StandTaken;
        public event Action<Stand> StandLost;
        public event Action<Obstacle> ObstacleTaken;
        public event Action<Barrier> BarrierTaken;
        public event Action YokeEventTaken;
        public event Action YokeEventEnded;
    }
}
