using UnityEngine;
using UnityEngine.Playables;

namespace CarAssembler
{
    public class KatSceneLooper : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _director;
        [SerializeField] private double _time;

        public void SetPlayTime()
        {
            _director.time = _time;
        }
    }
}
