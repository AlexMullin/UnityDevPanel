using UnityEngine;
using DeveloperMenu.DebugItems;

namespace DeveloperMenu
{
    /// <summary>
    /// DebugBehavior acts as a reference count to the debug panel. It should be instantiated using DebugPanel.Instance.CreateDebugEvent.
    /// </summary>
    public class DebugItemReference : MonoBehaviour
    {

        private DebugItem _item;
        public DebugItem Item => _item;

        public void Initialize(DebugItem i)
        {
            _item = i;
        }

        private void OnEnable()
        {
            if (Item == null) return;
            
            Item.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            if (Item == null) return;

            Item.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (Item != null)
            {
                Item.RequestDestroy();
            }
        }
    }

}
