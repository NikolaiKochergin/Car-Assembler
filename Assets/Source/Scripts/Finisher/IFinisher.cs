using System;

namespace CarAssembler
{
    public interface IFinisher
    {
        public void Show(Action ended);
    }
}