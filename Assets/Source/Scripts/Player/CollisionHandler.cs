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
            var quickTimeEvent = other.GetComponent<QuickTimeEvent>();
            
            if(factoryMachine)
                StandTaken?.Invoke(factoryMachine);
            
            if(obstacle)
                ObstacleTaken?.Invoke(obstacle);
            
            if(barrier)
                BarrierTaken?.Invoke(barrier);
            
            if(quickTimeEvent)
                QuickTimeEventTaken?.Invoke(quickTimeEvent);
        }

        private void OnTriggerExit(Collider other)
        {
            var factoryMachine = other.GetComponent<Stand>();
            var quickTimeEvent = other.GetComponent<QuickTimeEvent>();
            
            if(factoryMachine)
                StandLost?.Invoke(factoryMachine);
            
            if(quickTimeEvent)
                QuickTimeEventEnded?.Invoke();
        }

        public event Action<Stand> StandTaken;
        public event Action<Stand> StandLost;
        public event Action<Obstacle> ObstacleTaken;
        public event Action<Barrier> BarrierTaken;
        public event Action<QuickTimeEvent> QuickTimeEventTaken;
        public event Action QuickTimeEventEnded;
    }
}
