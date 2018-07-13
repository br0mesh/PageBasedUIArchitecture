using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageBasedUI
{
    public interface IPageStack
    {
        IPage Pop();
        IPage Peek();
        void Push(IPage page);
    }
}
