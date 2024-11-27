using System;
using System.Collections.Generic;
using UnityEngine;

namespace DevPanel
{

    public class DebugPanel : MonoBehaviour 
    {
        public static DebugPanel Instance { get; private set; }
        
        [Header("Prefabs")]
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private GameObject tabPrefab;

        [Header("GameObjects")]
        [SerializeField] private GameObject mainPanel;
        public GameObject MainPanel => mainPanel;

        private CursorLockMode previousCursorLockMode;
        private bool previousCursorVisibility;

        private Dictionary<string, GameObject> buttonTabs;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad0) && Application.isEditor)
            {
                SetMenuActive(!MainPanel.activeInHierarchy);

                
            }

        }
        private void OnDestroy()
        {
            Instance = null;
        }

        public void SetMenuActive(bool b)
        {
            MainPanel.SetActive(b);

            if (MainPanel.gameObject.activeSelf) //If the menu is opened, unlock the cursor, taking note of the current lockstate.
            {
                previousCursorLockMode = Cursor.lockState;
                Cursor.lockState = CursorLockMode.None;

                previousCursorVisibility = Cursor.visible;
                Cursor.visible = true;
            }
            else //If the menu is closed, return cursor to how it was
            {
                Cursor.lockState = previousCursorLockMode;
                Cursor.visible = previousCursorVisibility;
            }
        }
        
        /// <summary>
        /// Generate Elements to place in the Debug Panel
        /// </summary>
        public static class Make
        {
            /// <summary>
            /// Places a key on a gameObject as a component that remotely controls the debug item
            /// </summary>
            /// <param name="item"></param>
            /// <param name="owner">GameObject to put the key on</param>
            private static void Register(DebugItem item, GameObject owner)
            {
                DebugItemReference key = owner.AddComponent<DebugItemReference>();
                key.Initialize(item);
            }

            /// <summary>
            /// Crates a button that calls a function when clicked
            /// </summary>
            /// <param name="header">Name, Parent, and Owner of the DebugItem</param>
            /// <param name="action">What does the button do? <code> () => {Debug.Log("Button Clicked!");}</code></param>
            /// <param name="settings">Additional Settings of the button (Example new(ShowOnDisabled: true)</param>
            /// <returns></returns>
            public static DebugButton Button(DebugItem.Header header, Action action, DebugItem.Settings settings = new())
            {
                DebugButton db = Instantiate(Instance.buttonPrefab, header.parent).GetComponent<DebugButton>();
                db.Initialize(header, action, settings);

                if (header.owner != null)
                {
                    Register(db, header.owner.gameObject);
                }

                return db;
            }

            /// <summary>
            /// Create a tab
            /// </summary>
            /// <param name="header">Name, Parent, and Owner of the DebugItem</param>
            /// <param name="settings">Additional Settings of the button (Example new(</param>
            public static DebugTab Tab(DebugItem.Header header, DebugItem.Settings settings = new())
            {
                DebugTab tab = Instantiate(Instance.tabPrefab, header.parent).GetComponent<DebugTab>();
                tab.Initialize(header, settings);

                if (header.owner != null)
                {
                    Register(tab, header.owner.gameObject);
                }

                return tab;
            }
        }
    }
}