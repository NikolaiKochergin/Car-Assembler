using UnityEngine;

namespace CarAssembler
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private SlotType _slotType;

        public SlotType SlotType => _slotType;
        public Detail Content { get; private set; }

        private void OnValidate()
        {
            gameObject.name = _slotType + "Slot";
        }

        public void TakeOrReplace(Detail detail)
        {
            if (Content)
                Content.Hide();

            Content = Instantiate(detail, transform);
            Content.transform.SetPositionAndRotation(transform.position, transform.rotation);
            Content.transform.localScale = Vector3.one;
            Content.Show();
        }

        public void ClearContent()
        {
            if (Content)
                Content.Hide();
            Content = null;
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
        Engine,
        Tuning,
        Bumper
    }
}