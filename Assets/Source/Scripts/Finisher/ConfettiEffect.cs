using UnityEngine;

namespace CarAssembler
{
    public class ConfettiEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _confettiEffect;

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (player)
            {
                if(_confettiEffect)
                    _confettiEffect.Play();
                
                Debug.Log("Finisher");
            }
        }
    }
}