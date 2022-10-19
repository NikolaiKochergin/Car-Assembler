using System.Collections.Generic;

namespace CarAssembler
{
    public interface ITaskChecker
    {
        public IFinisher GetFinisherBy(IReadOnlyList<Task> tasks, Car car);
    }
}
