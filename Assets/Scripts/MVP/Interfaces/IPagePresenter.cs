using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageBasedUI.MVP
{
    public interface IPagePresenter
    {
        void Init();
        void SetActive(bool value);
        void SetActiveUIElements(bool value);
        void SetActiveLoadBar(bool value);
    }
}
