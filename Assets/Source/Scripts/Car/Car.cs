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

        private List<Detail> _details = new();
        private int _carPrice;

        public IReadOnlyList<Detail> Details => _details;
        public IReadOnlyList<Rigidbody> RigidbodiesDetails => _rigidbodiesDetails;
        public CarExplosion CarExplosion => _carExpolsion;

        public int CarPrice
        {
            get => _carPrice;
            private set
            {
                _carPrice = value;
                CarPriceChanged?.Invoke(value);
            }
        }

        public event Action<int> CarPriceChanged;

        public bool TryTakeDetail(Detail detail)
        {
            var spawnedDetail = Instantiate(detail, _model);
            _details.Add(spawnedDetail);

            if (detail.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                _rigidbodiesDetails.Add(rigidbody);
            
            return true;
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