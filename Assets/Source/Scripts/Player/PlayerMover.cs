using Dreamteck.Splines;
using UnityEngine;

namespace CarAssembler
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private SplineFollower _splineFollower;
        private void Start()
        {
            _splineFollower.follow = false;
        }

        public void StartMove()
        {
            _splineFollower.follow = true;
        }

        public void StopMove()
        {
            _splineFollower.follow = false;
        }
    }
}