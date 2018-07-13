using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PageBasedUI
{
    public class BasePageController : MonoBehaviour, IPageController
    {
        [SerializeField] private BaseLoadBar loadBar;
        [SerializeField] private BaseNetworkReachability networkReachability;
        [SerializeField] private List<IPage> pages;

        private IPageStack pageStack;

        #region IPageController

        public ILoadBar LoadBar { get { return loadBar as ILoadBar; } }

        public INetworkReachability NetworkReachability { get { return networkReachability as INetworkReachability; } }

        public IPageStack PageStack { get { return pageStack as IPageStack; } }

        public event OnButtonBackPressed onButtonBackPressed;

        public void ReturnOnPreviousPage()
        {
            pageStack.Pop();
            pageStack.Pop();

            SwitchPageOn(pageStack.Peek());
        }

        public void SwitchPageOn<T>() where T : IPage
        {
            int currentPageIndex = 0;

            for (int i = 0; i < pages.Count; i++)
            {
                if (pages[i].GetType() != typeof(T))
                {
                    pages[i].SetActive(false);
                }
                else
                {
                    currentPageIndex = i;
                }
            }

            pages[currentPageIndex].SetActive(true);

            pageStack.Push(pages[currentPageIndex]);
        }

        public void SwitchPageOn(IPage pageTo)
        {
            int currentPageIndex = 0;

            for (int i = 0; i < pages.Count; i++)
            {
                if (pages[i] != pageTo)
                {
                    pages[i].SetActive(false);
                }
                else
                {
                    currentPageIndex = i;
                }
            }

            pages[currentPageIndex].SetActive(true);

            pageStack.Push(pages[currentPageIndex]);
        }

        #endregion IPageController
        
        private void Awake()
        {
            StartCoroutine(TrackableButtonBack());

            pages = new List<IPage>();
            pages.AddRange(GetComponentsInChildren<IPage>());

            pageStack = new BasePageStack();
            for (int i = 0; i < pages.Count; i++)
            {
                pages[i].Init();
            }
            Debug.Log(pages.Count);

            SwitchPageOn(pages[0]);
        }

        private void ButtonBackPressed()
        {
            if(onButtonBackPressed != null)
            {
                onButtonBackPressed();
            }
        }

        private IEnumerator TrackableButtonBack()
        {
            while(true)
            {
                if(Input.GetButtonDown("Cancel"))
                {
                    ButtonBackPressed();
                }
                yield return null;
            }
        }
    }
}
