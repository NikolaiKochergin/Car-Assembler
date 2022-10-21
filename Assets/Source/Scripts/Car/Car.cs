using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class Car : MonoBehaviour, IPhysics
    {
        [SerializeField] private Transform _model;
        [SerializeField] private CarExplosion _carExpolsion;
        [SerializeField] private List<Rigidbody> _rigidbodiesDetails;

        private readonly List<Detail> _details = new();

        public IReadOnlyList<Detail> Details => _details;
        public CarFeatures Features { get; private set; }
        public IReadOnlyList<Rigidbody> RigidbodiesDetails => _rigidbodiesDetails;
        public CarExplosion CarExplosion => _carExpolsion;

        private void Awake()
        {
            Features = new CarFeatures();
        }

        public void TakeDetail(Detail detail)
        {
            var spawnedDetail = Instantiate(detail, _model);
            _details.Add(spawnedDetail);

            if (detail.TryGetComponent(out Rigidbody rigidbody))
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