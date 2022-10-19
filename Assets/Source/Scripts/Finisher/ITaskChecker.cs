using System.Collections.Generic;

namespace CarAssembler
{
    public interface ITaskChecker
    {
        public IReadOnlyList<IFinisher> Finishers { get; }

        public void SetFinisher(IReadOnlyList<Task> tasks, IReadOnlyList<Detail> details);
    }
}
