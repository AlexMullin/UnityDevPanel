using System;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;
namespace DevPanel
{
    public class DebugButton : DebugItem
    {
        [SerializeField] private Button button;

        private event Action action;

        public void Initialize(Header header, Action debugAction, Settings s = new())
        {
            _header = header;

            name = header.name;
            label.text = header.name;

            action = debugAction;
            _settings = s;

            button.onClick.AddListener(action.Invoke);
            if(s.closeDebugOnClick) button.onClick.AddListener(()=>DebugPanel.Instance.SetMenuActive(false));
        }
    }

}
