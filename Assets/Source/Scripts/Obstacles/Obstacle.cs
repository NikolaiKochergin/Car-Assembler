using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _price;

        private ObstacleChecker _obstacleChecker;

        private void Start()
        {
            _obstacleChecker = GetComponentInChildren<ObstacleChecker>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (player)
                if (!_obstacleChecker.IsOpen)
                    Debug.Log("Hited");
            // player.OnHited(_price);
            //сделать публичный метод в плеере и передать сумму штрафа ?
        }

        public void Disable()
        {
            // Сюда можно запихнуть какую то логику.

            gameObject.SetActive(false);
        }
    }
}