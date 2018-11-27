using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PageBasedUI
{
    class UniquePage : BasePage
    {
        [SerializeField] private Button basePageButton;

       override public void Init()
        {
           
            base.Init();
            basePageButton.onClick.AddListener(BasePageButtonPressed);
        }

        private void BasePageButtonPressed()
        {
            pageController.SwitchPageOn<BasePage>();
        }

        override public void SetActive(bool value)
        {
            base.SetActive(value);
            if(value)
            {
                Debug.Log("Unique Page");
            }
        }
    }
}
