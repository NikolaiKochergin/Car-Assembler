using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CarAssembler
{
    public class StartButton : MonoBehaviour, IPointerDownHandler
    {
        public event Action ButtonPressedDown;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            ButtonPressedDown?.Invoke();
        }
    }
}
