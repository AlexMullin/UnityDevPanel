using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace DeveloperMenu.DebugItems
{
    public class DebugTab : DebugItem
    {
        [Header("GameObjects", order = 1)]
        [SerializeField] private Button button;
        [SerializeField] private Text plusMinusText;
        [SerializeField] private GameObject itemContainer;

        public override Transform GetItemContainer() => itemContainer.transform;

        public void Initialize(Header h)
        {
            _header = h;

            label.text = h.name;
            name = h.name;
        }

        /// Called by TextContent Button
        public void ToggleTab()
        {
            itemContainer.SetActive(!itemContainer.activeSelf);

            plusMinusText.text = itemContainer.activeSelf ? "-" : "+";

        }

        public async void OnSubItemDestroyed()
        {
            await Task.Delay(1); //Delay required to properly recognize the change in childcount

            Debug.Log($"{header.name}: Sub Item Destroyed, remaining subitems: {GetItemContainer().childCount}", this);
            if (GetItemContainer().childCount == 0)
            {
                RequestDestroy();
            }
        }
    }

}
