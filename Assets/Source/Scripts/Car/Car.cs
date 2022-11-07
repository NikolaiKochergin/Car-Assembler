using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    public class Car : MonoBehaviour, IPhysics
    {
        [SerializeField] private Transform _model;
        [SerializeField] private CarFinishReaction _carExpolsion;
        [SerializeField] private List<Rigidbody> _rigidbodiesDetails;
        
        private readonly List<Detail> _details = new();
        private List<Wheel> _currentWheels;
        private IReadOnlyList<Slot> _slots;

        public IReadOnlyList<Detail> Details => _details;
        public CarFeatures Features { get; private set; }
        public CarFeatures PreliminaryFeatures { get; private set; }
        public IReadOnlyList<Rigidbody> RigidbodiesDetails => _rigidbodiesDetails;
        public CarFinishReaction CarExplosion => _carExpolsion;
        public IReadOnlyList<Wheel> CurrentWheels => _currentWheels;

        private void Awake()
        {
            Features = new CarFeatures();
            PreliminaryFeatures = new CarFeatures();
        }

        public void Initialize(IReadOnlyList<Slot> slots)
        {
            _slots = slots;
        }

        public void TakeDetail(Detail detail)
        {
            Transform parent = _model;
            Slot wheelSlot = null;
            
            foreach (var slot in _slots)
            {
                if (slot.SlotType == detail.Features.Slot)
                {
                    parent = slot.transform;
                    wheelSlot = slot;
                    break;
                }
            }

            var spawnedDetail = Instantiate(detail, parent);
            spawnedDetail.PlayParticle();
            _details.Add(spawnedDetail);
            
            if (_currentWheels == null && spawnedDetail.Features.Slot == SlotType.Wheels)
            {
                _currentWheels = spawnedDetail.GetComponentsInChildren<Wheel>().ToList();
                foreach (var wheel in _currentWheels)
                {
                    wheel.Initialize();
                }
            }
            if (spawnedDetail.Features.Slot == SlotType.Wheels && wheelSlot != null)
            {
                var wheelsList = spawnedDetail.GetComponent<WheelsList>();
                var wheelsSlots = wheelSlot.GetComponent<WheelSlots>();

                if (wheelsList == null)
                    throw new ArgumentNullException($"Wheels Detail doesn't contain {nameof(WheelsList)}");
                if (wheelsSlots == null)
                    throw new ArgumentNullException($"Player Wheels Slot doesn't contain {nameof(WheelSlots)}");

                for (int i = 0; i < wheelsList.Wheels.Count; i++)
                {
                    wheelsList.Wheels[i].transform.parent = wheelsSlots.Slots[i].transform;
                }
            }

            if (spawnedDetail.TryGetComponent(out Rigidbody rigidbody))
                _rigidbodiesDetails.Add(rigidbody);

            Features.CalculateCarFeatures(_details);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}