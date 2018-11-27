using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PageBasedUI.MVP
{
    public class PageContainer : MonoBehaviour, IPageContainer
    {
        private static PageContainer _instance;
        public static PageContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PageContainer();
                }

                return _instance;
            }
        }

        [SerializeField] protected BaseLoadBar _loadBar;
        [SerializeField] protected BaseNetworkReachability _networkReachability;
        private List<IPagePresenter> _pagePresenters;
        protected IPagePesenterStack _pageStack;

        #region IPageContainer

        public ILoadBar LoadBar { get { return _loadBar as ILoadBar; } }

        public INetworkReachability NetworkReachability { get { return _networkReachability as INetworkReachability; } }

        public IPagePesenterStack PageStack { get { return _pageStack as IPagePesenterStack; } }

        public event OnButtonBackPressed onButtonBackPressed;

        public void SwitchPageOn<T>() where T : IPagePresenter
        {
            int currentPageIndex = 0;

            for (int i = 0; i < _pagePresenters.Count; i++)
            {
                if (_pagePresenters[i].GetType() != typeof(T))
                {
                    _pagePresenters[i].SetActive(false);
                }
                else
                {
                    currentPageIndex = i;
                }
            }

            _pagePresenters[currentPageIndex].SetActive(true);

            _pageStack.Push(_pagePresenters[currentPageIndex]);
        }

        public void SwitchPageOn(IPagePresenter pageTo)
        {
            int currentPageIndex = 0;

            for (int i = 0; i < _pagePresenters.Count; i++)
            {
                if (_pagePresenters[i] != pageTo)
                {
                    _pagePresenters[i].SetActive(false);
                }
                else
                {
                    currentPageIndex = i;
                }
            }

            _pagePresenters[currentPageIndex].SetActive(true);

            _pageStack.Push(_pagePresenters[currentPageIndex]);
        }

        public void ReturnOnPreviousPage()
        {
            _pageStack.Pop();
            _pageStack.Pop();

            SwitchPageOn(_pageStack.Peek());
        }

        #endregion //IPageContainer

        private void Awake()
        {
            StartCoroutine(TrackableButtonBack());

            _pagePresenters = new List<IPagePresenter>();
            _pagePresenters.AddRange(GetComponentsInChildren<IPagePresenter>());

            _pageStack = new PagePresenterStack();
            for (int i = 0; i < _pagePresenters.Count; i++)
            {
                _pagePresenters[i].Init();
            }
            Debug.Log(_pagePresenters.Count);

            SwitchPageOn(_pagePresenters[0]);
        }

        private void ButtonBackPressed()
        {
            if (onButtonBackPressed != null)
            {
                onButtonBackPressed();
            }
        }

        private IEnumerator TrackableButtonBack()
        {
            while (true)
            {
                if (Input.GetButtonDown("Cancel"))
                {
                    ButtonBackPressed();
                }
                yield return null;
            }
        }
    }
}
