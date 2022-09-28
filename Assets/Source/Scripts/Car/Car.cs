using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    public class Car : MonoBehaviour
    {
        [SerializeField] private List<Slot> _slots;

        public int Price { get; private set; }

        private void Start()
        {
            Price = 0;
            PriceChanged?.Invoke(Price);
        }

        public event Action<int> PriceChanged;

        public void TakeDetail(Detail detail)
        {
            var slot = _slots.FirstOrDefault(s => s.SlotType == detail.SlotType);
            if (slot != null)
            {
                if (slot.Content)
                    Price -= slot.Content.Price;

                slot.TakeOrReplace(detail);
                Price += detail.Price;
                PriceChanged?.Invoke(Price);
            }
            else
            {
                Debug.Log("В этой машине нет слота типа " + detail.SlotType);
            }
        }
    }
}