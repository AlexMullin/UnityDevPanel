using UnityEngine;

namespace DevPanel
{
    /// <summary>
    /// DebugBehavior acts as a reference count to the debug panel. It should be instantiated using DebugPanel.Instance.CreateDebugEvent.
    /// </summary>
    public class DebugItemReference : MonoBehaviour
    {

        [SerializeReference] private DebugItem _item;
        public DebugItem Item => _item;

        public void Initialize(DebugItem i)
        {
            _item = i;
            if (!Item.settings.showDisabled) Item.gameObject.SetActive(gameObject.activeInHierarchy);
        }

        private void OnEnable()
        {
            if (Item == null) return;
            
            Item.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            if (Item == null) return;

            if (!Item.settings.showDisabled) Item.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (Item != null)
            {
                Destroy(Item.gameObject);
            }
        }
    }

}
