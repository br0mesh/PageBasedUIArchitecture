using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PageBasedUI
{
    public interface IPageController
    {
        ILoadBar LoadBar { get; }
        INetworkReachability NetworkReachability { get; }
        IPageStack PageStack { get; }

        event OnButtonBackPressed onButtonBackPressed;

        void SwitchPageOn<T>() where T : IPage;
        void SwitchPageOn(IPage pageTo);

        void ReturnOnPreviousPage();


        //void ButtonBackPressed();
    }

    public delegate void OnButtonBackPressed();

}
