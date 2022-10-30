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

        public IReadOnlyList<Detail> Details => _details;
        public CarFeatures Features { get; private set; }
        public CarFeatures PreliminaryFeatures { get; private set; }
        public IReadOnlyList<Rigidbody> RigidbodiesDetails => _rigidbodiesDetails;
        public CarFinishReaction CarExplosion => _carExpolsion;
        public List<Wheel> CurrentWheels => _currentWheels;

        private void Awake()
        {
            Features = new CarFeatures();
            PreliminaryFeatures = new CarFeatures();
        }

        public void StopRotationWheels()
        {
            for (int i = 0; i < _currentWheels.Count; i++)
            {
                _currentWheels[i].Disable();
            }
        }

        public void StartRotationWheels()
        {
            for (int i = 0; i < _currentWheels.Count; i++)
            {
                _currentWheels[i].Enable();
            }
        }

        public void TakeDetail(Detail detail)
        {
            var spawnedDetail = Instantiate(detail, _model);
            spawnedDetail.PlayParticle();
            _details.Add(spawnedDetail);

            if (_currentWheels == null && spawnedDetail.Features.Slot == SlotType.Wheels)
            {
                _currentWheels = spawnedDetail.GetComponentsInChildren<Wheel>().ToList();
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