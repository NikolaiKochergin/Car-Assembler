using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler {
    public class DetailSwiper : MonoBehaviour
    {
        [SerializeField] private List<Detail> _details;

        private Vector3 _currentMousePosition;

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                Debug.Log("DetailSwiper");
                Swipe();
            }
        }



        private void Swipe()
        {

            Vector3 currentMousePosition = Input.mousePosition;
            if (currentMousePosition.x < Input.mousePosition.x)
            {
                Debug.Log("<<<<<");
            }
            else if (currentMousePosition.x > Input.mousePosition.x)
            {
                Debug.Log(">>>>>>>");
            }

            //_currentMousePosition
        }
    }
}
