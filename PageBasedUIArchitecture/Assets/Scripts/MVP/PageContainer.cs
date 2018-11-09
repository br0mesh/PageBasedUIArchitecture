using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageBasedUI.MVP
{
    public class PageContainer
    {
        private static PageContainer _instance;
        public static PageContainer Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new PageContainer();
                }

                return _instance;
            }
        }

        private PageContainer()
        {
            if(_instance != null)
            {
                return;
            }

        }

        private List<PagePresenter> _pagePresenters;


        public void SwitchPageOn<T>() where T : IPage
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

            //pageStack.Push(pages[currentPageIndex]);
        }
    }
}
