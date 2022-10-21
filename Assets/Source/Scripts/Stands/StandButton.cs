using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CarAssembler
{
    public class StandButton : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
    {
        public bool IsPointerOnButton { get; private set; }
        
        private void Update()
        {
            if (Input.GetMouseButtonUp(0)) IsPointerOnButton = false;
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

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPointerOnButton = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsPointerOnButton = false;
            Clicked?.Invoke();
        }
    }
}