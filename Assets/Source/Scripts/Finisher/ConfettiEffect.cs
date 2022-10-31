using UnityEngine;

namespace CarAssembler
{
    public class ConfettiEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] _finishLineEffect;

        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player>();

            if (player)
            {
                foreach (var effect in _finishLineEffect)
                {
                    if (effect)
                        effect.Play();
                }
            }
        }
    }
}