using System;
using UnityEngine;

namespace CarAssembler
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotType _slotType;

        public SlotType SlotType => _slotType;
        public Detail Content { get; private set; }

        public void TakeOrReplace(Detail detail)
        {
            if (Content)
                Content.Hide();

            Content = detail;
            detail.transform.parent = transform;
            detail.transform.SetPositionAndRotation(transform.position, transform.rotation);
            detail.Show();
        }

        public void ClearContent()
        {
            if (Content)
                Content.Hide();
            Content = null;
        }

        private void OnValidate()
        {
            gameObject.name = _slotType + "Slot";
        }
    }

    public enum SlotType
    {
        Empty,
        Frame,
        Doors,
        Windows,
        Wheels,
        Spoiler,
        Engine
    }
}