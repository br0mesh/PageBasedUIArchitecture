using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageBasedUI.MVP
{
    public interface IPagePesenterStack
    {
        IPagePresenter Pop();
        IPagePresenter Peek();
        void Push(IPagePresenter page);
    }
}
