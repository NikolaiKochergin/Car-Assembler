using System;

namespace CarAssembler
{
    public interface IFinisher
    {
        public IRace Race { get; }
        public void Show(Action ended);
    }
}