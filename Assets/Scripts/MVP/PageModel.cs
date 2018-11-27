using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;
using UniRx;

namespace PageBasedUI.MVP
{
    [Serializable]
    public class PageModel
    {
        public BoolReactiveProperty IsActive = new BoolReactiveProperty();
        public BoolReactiveProperty IsUIActive = new BoolReactiveProperty();
        public BoolReactiveProperty IsLoadBarActive = new BoolReactiveProperty();
    }
}
