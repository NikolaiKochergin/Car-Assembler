using UnityEngine;

namespace CarAssembler
{
    public class PlayerMover : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("Скрипт для тестов, потом перепишу.");
            enabled = false;
        }

        private void Update()
        {
            transform.position += Vector3.forward * 2f * Time.deltaTime;
        }

        public void StartMove()
        {
            enabled = true;
        }

        public void StopMove()
        {
            enabled = false;
        }
    }
}