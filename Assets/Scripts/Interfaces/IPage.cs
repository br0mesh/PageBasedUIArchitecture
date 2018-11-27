using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageBasedUI
{
    public interface IPage
    {
        IPageController PageController { get; }

        bool IsActive { get; }
        bool IsUIElementsActive { get; }
        bool IsLoadBarActive { get; }

        void Init();
        void SetActive(bool value);
        void SetActiveUIElements(bool value);
        void SetActiveLoadBar(bool value);
    }
}
