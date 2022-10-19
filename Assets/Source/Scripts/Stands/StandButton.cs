using System;
using UnityEngine;

namespace CarAssembler
{
    public class StandButton : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit) && hit.collider.gameObject == gameObject) Clicked?.Invoke();
            }
        }

        public event Action Clicked;

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