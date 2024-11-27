using DevPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Creates a tab that is not remotely controlled
        DebugTab tabUncontrolled = DebugPanel.Make.Tab(new("NewTab"));


        //Create a tab that is controlled by this gameObject, but stays open when 
        DebugTab tabControlled = DebugPanel.Make.Tab(
            new("This tab does not disable", tabUncontrolled, gameObject),
            new(showDisabled: true)
            );

        //Create a tab that is controlled by this gameObject that hides when Tab Maker is Disabled
        DebugTab tabControlledHides =  DebugPanel.Make.Tab(
            new("Disabling Tab", tabUncontrolled, gameObject)
            );

        //Tabs can nest as many times as you need
        DebugTab tabDoubleNested = DebugPanel.Make.Tab(
            new("Double nested tab", tabControlled)
            );

        //Create a button under a target tab
        DebugButton buttonUnControlled = DebugPanel.Make.Button(
            new("Press me!", tabDoubleNested),
            foo
            );

        //Buttons for functions with parameters should use Lambda Expressions
        DebugButton buttonUncontrolledWithParameter = DebugPanel.Make.Button(
            new("Press me!", tabControlledHides),
            () => fooWithParameter(5)
            );


        //It is also possible to tie buttons to other tabs
        DebugPanel.Make.Button(
            new("This Button Hides!", tabControlled, tabControlledHides.gameObject),
            () => { Debug.Log("You pressed the hidden button!"); }
            );

        //It is also possible to tie buttons to other tabs, if you find that important
        DebugPanel.Make.Button(
            new("This button hides!", tabUncontrolled, tabDoubleNested.gameObject),
            () => { Debug.Log("You pressed the hidden button!"); }

            );

        DebugPanel.Make.Button(new("Button"), () => Debug.Log("Hehe"));
    }

    private void foo()
    {
        Debug.Log("You clicked the button!");
    }

    private void fooWithParameter(int a)
    {
        Debug.Log("You clicked the button with parameter: " + a);
    }
}
