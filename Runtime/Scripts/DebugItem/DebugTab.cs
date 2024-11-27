using UnityEngine;
using UnityEngine.UI;

namespace DevPanel
{
    public class DebugTab : DebugItem
    {
        [Header("GameObjects", order = 1)]
        [SerializeField] private Button button;
        [SerializeField] private Text plusMinusText;
        [SerializeField] private GameObject itemContainer;

        public override Transform GetItemContainer() => itemContainer.transform;

        public void Initialize(Header h, Settings s)
        {
            _header = h;
            _settings = s;

            label.text = h.name;
            name = h.name;

            Debug.Log($"Header 1: {header.name}");
            Debug.Log($"Header 2: {h.name}");
        }

        public void ToggleTab()
        {
            itemContainer.SetActive(!itemContainer.activeSelf);

            plusMinusText.text = itemContainer.activeSelf ? "-" : "+";

        }
    }

}
