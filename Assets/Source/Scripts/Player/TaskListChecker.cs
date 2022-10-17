using UnityEngine;

namespace CarAssembler
{
    public class TaskListChecker : MonoBehaviour
    {
        private LevelSetup _levelSetup;
        private int _carPrice;

        public void SetTaskList(LevelSetup _levelSetup)
        {
            this._levelSetup = _levelSetup;
        }

        public void CheckTaskList(Detail detail)
        {
        }
    }
}
