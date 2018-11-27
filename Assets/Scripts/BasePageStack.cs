using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageBasedUI
{
    public class BasePageStack : IPageStack
    {
        Stack<IPage> stack = new Stack<IPage>();

        #region IPageStack

        public IPage Peek()
        {
            return stack.Peek();
        }

        public IPage Pop()
        {
            if (stack.Count > 1)
            {
                return stack.Pop();
            }
            else
            {
                return stack.Peek();
            }
        }

        public void Push(IPage page)
        {
            stack.Push(page);
        }

        #endregion IPageStack
    }
}
