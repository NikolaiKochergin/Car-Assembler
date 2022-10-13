using UnityEngine;

namespace CarAssembler
{
    public class TaskListChecker : MonoBehaviour
    {
        private TaskList _taskList;
        private int _carPrice;

        public void SetTaskList(TaskList taskList)
        {
            _taskList = taskList;
        }

        public void CheckTaskList(Detail detail)
        {
            foreach (var feature in detail.Features)
            {
                if (feature == _taskList.Tasks[0].CarType)
                {
                    _carPrice += detail.Price;
                }
            }
        }
    }
}
