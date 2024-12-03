using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeveloperMenu.Tests
{
    public class MakeButtonsInTab : MonoBehaviour
    {
        [SerializeField] GameObject ownerA;
        [SerializeField] GameObject ownerB;
        [SerializeField] GameObject ownerC;
        private void ClickButton()
        {
            Debug.Log("Button Clicked!");
        }

        // Start is called before the first frame update
        void Start()
        {
            DevMenu.Make.Button(new("ButtonLevel0", owner: ownerA), ClickButton);
            DevMenu.Make.Button(new("ButtonLevel0", owner: ownerB), ClickButton);
            DevMenu.Make.Button(new("ButtonLevel0", owner: ownerC), ClickButton);

            DevMenu.Make.Button(new("Button", "Level1A", ownerA), ClickButton);
            DevMenu.Make.Button(new("Button", "Level1A", ownerB), ClickButton);
            DevMenu.Make.Button(new("Button", "Level1B", ownerC), ClickButton);
                
            DevMenu.Make.Button(new("Button", "Level1A/Tab"), ClickButton);
            DevMenu.Make.Button(new("Button", "Level1A/Tab/NewSubtab"), ClickButton);

            DevMenu.Make.Button(new("Button", "Level1B/Subtab", ownerC), ClickButton);
            DevMenu.Make.Button(new("Button", "Level1B/Subtab", ownerC), ClickButton);
            DevMenu.Make.Button(new("Button", "Level1B/Subtab", ownerC), ClickButton);

        }
    }
}
