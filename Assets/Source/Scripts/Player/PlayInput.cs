using UnityEngine;

namespace CarAssembler
{
    public class PlayInput : MonoBehaviour
    {
        public bool IsMoving { get; private set; }
        
        private void Update()
        {
            if (Input.GetMouseButton(0))
                IsMoving = true;

            if (Input.GetMouseButtonUp(0))
                IsMoving = false;
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
            IsMoving = false;
        }
    }
}
