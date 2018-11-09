using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PageBasedUI.MVP
{
   public class PageView : MonoBehaviour
    {
        [SerializeField] private PagePresenter _presenter;

        public Text text;
        private void Awake()
        {
            _presenter.View = this;
            _presenter.Init();
        }
        public void SetupText(string text)
        {
            this.text.text = text;
        }
    }
}
