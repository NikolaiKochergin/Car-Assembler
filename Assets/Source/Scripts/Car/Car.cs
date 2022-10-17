using System;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private Transform _model;
        
        private List<Detail> _details;
        private int _carPrice;

        public IReadOnlyList<Detail> Details => _details;

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