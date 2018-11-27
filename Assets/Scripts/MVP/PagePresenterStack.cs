using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageBasedUI.MVP
{
    public class PagePresenterStack : IPagePesenterStack
    {
        public IPagePresenter Peek()
        {
            throw new NotImplementedException();
        }

        public IPagePresenter Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(IPagePresenter page)
        {
            throw new NotImplementedException();
        }
    }
}
