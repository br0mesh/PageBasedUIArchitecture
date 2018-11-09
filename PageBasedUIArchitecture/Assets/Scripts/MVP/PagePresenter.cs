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
    public class PagePresenter
    {
        [SerializeField] private PageModel _model;
        [HideInInspector] public PageView View;

        public void Init()
        {
            _model.IsActive.Subscribe(_ => { View.SetupText("Page is " +_model.IsActive.Value.ToString()); });
            _model.IsUIActive.Subscribe(_ => { View.SetupText("Page UI is " + _model.IsUIActive.Value.ToString()); });
            _model.IsLoadBarActive.Subscribe(_ => { View.SetupText("Page load bar is " + _model.IsLoadBarActive.Value.ToString()); });
        }

        public void SetActive(bool value)
        {
            _model.IsActive.Value = value;
        }
    }
}
