using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    public class Car : Detail
    {
        [SerializeField] private List<Slot> _slots;
        
        public IReadOnlyList<Slot> Slots => _slots;

        public bool TryTakeDetail(Detail detail)
        {
            var slot = _slots.FirstOrDefault(s => s.SlotType == detail.SlotType);
            if (slot != null)
            {
                slot.TakeOrReplace(detail);
                return true;
            }

            return false;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            base.Show();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}