using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PageBasedUI
{

    public class BaseLoadBar : MonoBehaviour, ILoadBar
    {
        [SerializeField] protected Sprite[] _frames;
        [SerializeField] protected Image image;
        [SerializeField] protected int _framePerSecond = 10;

        [SerializeField] protected bool isActive;

        #region ILoadBar

        public bool IsActive { get { return isActive; } }

        public void SetActive(bool value)
        {
            image.enabled = value;
            isActive = value;
            StartCoroutine(LoadBarStart());
        }

        #endregion ILoadBar

        private IEnumerator LoadBarStart()
        {
            while (isActive)
            {
                int i = (int)((Time.time * _framePerSecond) % _frames.Length);
                image.sprite = _frames[i];
                yield return null;
            }
        }
    }
}
