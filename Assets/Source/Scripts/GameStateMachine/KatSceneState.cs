using UnityEngine.Playables;

namespace CarAssembler
{
    public class KatSceneState : IGameState
    {
        private readonly PlayableDirector _enterKatScene;
        private readonly UI _ui;
        
        public KatSceneState (PlayableDirector director, UI ui)
        {
            _enterKatScene = director;
            _ui = ui;
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
