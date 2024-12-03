using System;
using UnityEngine;
using UnityEngine.UI;
namespace DeveloperMenu.DebugItems
{
    public class DebugButton : DebugItem
    {
        [SerializeField] private Button button;

        private event Action action;

        public void Initialize(Header header, Action debugAction)
        {
            _header = header;

            name = header.name;
            label.text = header.name;

            action = debugAction;

            button.onClick.AddListener(action.Invoke);
        }
    }

}
