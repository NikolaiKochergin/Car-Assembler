using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CarAssembler
{
    public class Car : Detail
    {
        [SerializeField] private List<Slot> _slots;
        
        public IReadOnlyList<Slot> Slots => _slots;

        public bool TryTakeDetail(Stand stand)
        {
            var slot = _slots.FirstOrDefault(s => s.SlotType == stand.SlotType);
            if (slot != null)
            {
                slot.TakeOrReplace(stand);
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