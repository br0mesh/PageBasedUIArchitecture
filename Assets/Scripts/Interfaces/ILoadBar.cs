using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageBasedUI
{
    public interface ILoadBar
    {
        //To Do: stack of calling coz we can activate loadbar many times from different pager in one moment.
        // now if you activate loadbar twice and deactivate only one it will deactivate all of them
        bool IsActive { get; }

        void SetActive(bool value);

    }
}
