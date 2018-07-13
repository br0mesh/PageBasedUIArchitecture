using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PageBasedUI
{
    public class BaseNetworkReachability : MonoBehaviour, INetworkReachability
    {
        [SerializeField] protected GameObject errorWindow;

        #region INetworkReachability

        public bool CheckNetworkReachability()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("Internet : Not Reachable.");
                errorWindow.SetActive(true);

                return false;
            }
            else
            {
                Debug.Log("Internet is Reachable.");
                return true;
            }
        }

        #endregion INetworkReachability
    }
}
