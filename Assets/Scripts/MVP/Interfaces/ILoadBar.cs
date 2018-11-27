using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageBasedUI.MVP
{
    public interface ILoadBar
    {
        bool IsActive { get; }

        void SetActive(bool value);
    }
}
