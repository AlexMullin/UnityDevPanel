using UnityEngine;
using DeveloperMenu.DebugItems;

namespace DeveloperMenu
{
    /// <summary>
    /// DebugBehavior acts as a reference count to the debug panel. It should be instantiated using DebugPanel.Instance.CreateDebugEvent.
    /// </summary>
    public class DebugItemReference : MonoBehaviour
    {

        private DebugItem item;

        public void Initialize(DebugItem i)
        {
            item = i;
        }

        private void OnEnable()
        {
            if (item == null) return;
            
            item.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            if (item == null) return;

            item.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (item != null)
            {
                item.RequestDestroy();
            }
        }
    }

}
