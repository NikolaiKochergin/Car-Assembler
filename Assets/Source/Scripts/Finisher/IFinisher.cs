using System;

namespace CarAssembler
{
    public interface IFinisher
    {
        public event Action FinisherEnded;
        
        public void ShowFinisher(Car car);
    }
}