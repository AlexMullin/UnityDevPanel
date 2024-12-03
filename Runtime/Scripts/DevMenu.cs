using System;
using System.Collections.Generic;
using UnityEngine;

using DeveloperMenu.DebugItems;

namespace DeveloperMenu
{
    public class DevMenu : MonoBehaviour 
    {
        public static DevMenu Instance { get; private set; }
        
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
            if (Input.GetKeyDown(KeyCode.Keypad0))
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
            private static DebugTab FindOrMakeTab(string address)
            {
                /// <summary>
                /// Create a tab
                /// </summary>
                /// <param name="header">Name, Parent, and Owner of the DebugItem</param>
                /// <param name="settings">Additional Settings of the button (Example new(</param>
                DebugTab MakeTab(DebugItem.Header header, Transform parent)
                {
                    DebugTab tab = Instantiate(Instance.tabPrefab, parent).GetComponent<DebugTab>();
                    tab.Initialize(header);

                    return tab;
                }


                DebugTab currentTab = null;
                DebugTab previousTab = null;

                Transform currentLevel = Instance.MainPanel.transform;
                string addressBuild = "";

                foreach (string subtab in address.Split('/'))
                {
                    if (subtab == "") continue;

                    addressBuild += $"{subtab}";


                    currentTab = null;


                    //Search the current level for the correct tab
                    DebugTab[] tabResults = currentLevel.GetComponentsInChildren<DebugTab>();

                    foreach (DebugTab tab in tabResults)
                    {
                        if (tab.gameObject.name == subtab)
                        {
                            currentTab = tab;
                            break;
                        }
                    }

                    //If no tabs were found, make a new tab
                    if (currentTab == null)
                    {
                        currentTab = MakeTab(new(subtab, addressBuild), currentLevel);
                    }

                    if (previousTab != null)
                    {
                        currentTab.OnDestroyed += previousTab.OnSubItemDestroyed;
                    }

                    previousTab = currentTab;
                    currentLevel = currentTab.GetItemContainer();
                    addressBuild += "/";
                }

                if (currentTab != null) return currentTab;
                else return FindOrMakeTab("Uncategorized");
            }

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
            public static DebugButton Button(DebugItem.Header header, Action action)
            {
                DebugTab parentTab = FindOrMakeTab(header.address);

                DebugButton db = Instantiate(Instance.buttonPrefab, parentTab.GetItemContainer().transform).GetComponent<DebugButton>();
                
                db.Initialize(header, action);
                db.OnDestroyed += parentTab.OnSubItemDestroyed;


                if (header.owner != null)
                {
                    Register(db, header.owner.gameObject);
                }

                return db;
            }

        }
    }
}