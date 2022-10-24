using UnityEngine;

namespace CarAssembler
{
    [SelectionBase]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _price;

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}