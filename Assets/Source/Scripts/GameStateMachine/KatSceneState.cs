using UnityEngine.Playables;

namespace CarAssembler
{
    public class KatSceneState : IGameState
    {
        private readonly PlayableDirector _enterKatScene;
        
        public KatSceneState (PlayableDirector director)
        {
            _enterKatScene = director;
        }

        public void Enter()
        {
            _enterKatScene.Play();
        }

        public void Exit()
        {
            _enterKatScene.Stop();
        }
    }
}
