using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PageBasedUI
{
    public class BasePage : MonoBehaviour, IPage
    {
        [SerializeField] protected BasePageController pageController;

        [SerializeField] protected bool isActive;
        [SerializeField] protected bool isUIElementsActive;
        [SerializeField] protected bool isLoadBarActive;

        [SerializeField] protected GameObject[] uiElement;

        [SerializeField] protected Button backButton;

        #region IPage

        public IPageController PageController { get { return pageController as IPageController; } }

        public bool IsActive { get { return isActive; } }

        public bool IsUIElementsActive { get { return isUIElementsActive; } }

        public bool IsLoadBarActive { get { return isLoadBarActive; } }

        virtual public void Init()
        {
            backButton.onClick.AddListener(BackButtonPressed);
            Debug.Log(name);
        }

        virtual public void SetActive(bool value)
        {
            if (value == isActive) return;

            isActive = value;

            SetActiveUIElements(isActive);

            SubscribeOnButtonBackEvent(value);
        }

        virtual public void SetActiveLoadBar(bool value)
        {
            pageController.LoadBar.SetActive(value);
        }

        virtual public void SetActiveUIElements(bool value)
        {
            for (int i = 0; i < uiElement.Length; i++)
            {
                uiElement[i].SetActive(value);
            }
        }

        #endregion IPage

        virtual protected void BackButtonPressed()
        {
            pageController.ReturnOnPreviousPage();
        }

        virtual protected void SubscribeOnButtonBackEvent(bool value)
        {
            if (value)
            {
                pageController.onButtonBackPressed += BackButtonPressed;
            }
            else
            {
                pageController.onButtonBackPressed -= BackButtonPressed;
            }
        }
    }
}
