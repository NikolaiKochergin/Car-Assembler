using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private List<Slot> _slots;

        public IReadOnlyList<Slot> Slots => _slots;
        public int Price { get; private set; }

        private void Start()
        {
            Price = 0;
            PriceChanged?.Invoke(Price);
        }

        public event Action<int> PriceChanged;

        public bool TryTakeDetail(Detail detail)
        {
            var slot = _slots.FirstOrDefault(s => s.SlotType == detail.SlotType);
            if (slot != null)
            {
                if (slot.Content)
                    Price -= slot.Content.Price;

                slot.TakeOrReplace(detail);
                Price += detail.Price;
                PriceChanged?.Invoke(Price);
                return true;
            }

            Price -= detail.Price;
            if (Price < 0)
                Price = 0;
            
            PriceChanged?.Invoke(-detail.Price);
            Debug.Log("В этой машине нет слота типа " + detail.SlotType);
            Debug.Log("Тут нужно решить, будет ли штраф за не правильный выбор");
            return false;
        }
    }
}