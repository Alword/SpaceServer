using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceServer.Business.Abstractions
{
    public interface ICommand
    {
        public void Invoke(byte[] body);
    }
}
