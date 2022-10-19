using System;

namespace CarAssembler
{
    public interface IFinisher
    {
        public event Action FinisherEnded;
        
        public void Show();
    }
}