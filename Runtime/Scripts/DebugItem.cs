using System;
using UnityEngine;
using UnityEngine.UI;

namespace DeveloperMenu.DebugItems
{
    /// <summary>
    /// Base class for items that can be placed in the debug panel and have a reference created to them.
    /// </summary>
    public abstract class DebugItem : MonoBehaviour
    {
        [SerializeField] protected Text label;

        protected Header _header;
        public Header header => _header;
        public event Action OnDestroyed;
        
        /// <summary>
        /// Return a transform to place other DebugItems if applicable
        /// </summary>
        /// <returns></returns>
        public virtual Transform GetItemContainer() => null;

        public struct Header
        {
            public string name;
            public string address;
            public GameObject owner;


            /// <param name="name">Name of the item</param>
            /// <param name="address">Which folder to place the item in (example Ememies/Hobgoblin) Null = place in the top of the debug folder</param>
            /// <param name="owner">Object to create a <see cref="DebugItemReference"/> that remotely controls the debug item</param>
            public Header(string name, string address = "", GameObject owner = null)
            {
                this.name = name;
                this.address = address;
                this.owner = owner;
            }
        }

        public void RequestDestroy()
        {
            Destroy(gameObject);
            OnDestroyed?.Invoke();
        }
    }
}

