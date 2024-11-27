using Codice.Client.Common.Locks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DevPanel
{
    /// <summary>
    /// Base class for items that can be placed in the debug panel and have a reference created to them.
    /// </summary>
    public abstract class DebugItem : MonoBehaviour
    {
        [SerializeField] protected Text label;

        protected Settings _settings;
        public Settings settings => _settings;

        protected Header _header;
        public Header header => _header;
        


        /// <summary>
        /// Return a transform to place other DebugItems if applicable
        /// </summary>
        /// <returns></returns>
        public virtual Transform GetItemContainer() => null;



        /// <summary>
        /// Settings to pass into a newly created debugButton for controlling its behavior.
        /// </summary>
        public struct Settings
        {
            public bool showDisabled;
            public bool closeDebugOnClick;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="showDisabled">Show the item button even if the owner object is inactive?</param>
            /// <param name="closeDebugOnClick">Close the debug menu upon clicking the control.</param>
            public Settings(bool showDisabled = false, bool closeDebugOnClick = false, bool dontDestroyOnEmpty = false)
            {
                this.showDisabled = showDisabled;
                this.closeDebugOnClick = closeDebugOnClick;
            }
        }

        public struct Header
        {
            public string name;
            public Transform parent;
            public GameObject owner;


            /// <param name="name">Name of the item</param>
            /// <param name="parent">Where to parent the button. Null = place in the top of the debug folder</param>
            /// <param name="owner">Object to create a <see cref="DebugItemReference"/> that remotely controls the debug item</param>
            public Header(string name, DebugItem parent = null, GameObject owner = null)
            {
                this.name = name;
                this.parent = parent != null ? parent.GetItemContainer() : DebugPanel.Instance.MainPanel.transform;
                this.owner = owner;
            }
        }
    }
}

