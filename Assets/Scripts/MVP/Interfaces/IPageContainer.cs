using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageBasedUI.MVP
{
    public interface IPageContainer
    {
        ILoadBar LoadBar { get; }
        INetworkReachability NetworkReachability { get; }
        IPagePesenterStack PageStack { get; }

        event OnButtonBackPressed onButtonBackPressed;

        void SwitchPageOn<T>() where T : IPagePresenter;
        void SwitchPageOn(IPagePresenter pageTo);

        void ReturnOnPreviousPage();
    }
}
