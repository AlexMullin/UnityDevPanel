# INITIAL SETUP

**WARNING:** ERRORS WILL OCCUR IF YOU DO NOT DO THIS.

1. Place the Debug Panel Prefab in the scene's canvas
    1. For the best results, place the DebugPanel and canvas in a bootstrap scene or DontDestroyOnLoad object that is created before anything tries to use it.

# HOW TO USE

## Steps

1. After conducting the initial setup, open a script to one of your Game Objects that will appear in your scene.

2. The debug panel can be opened and closed by pressing **Ctrl + 0**

3. In the start function of your monobehavior, Place a button into the Debug Panel using **DebugPanel.Make.(Item)**

    * see Available Debug Items on which controls are available

4. When you want to test your fucntionality, open the panel and click the button

## DebugItem.Header

Headings for Debug Items. They contain the following information:

* Name of the Debug Item

* (Optional) Which Debug Item to parent them to
    * If no arguement is given, the debug item will not be placed inside of anything.

* (Optional) Which GameObject Owns the button

    * When a control is created and this is points to another gameObject, a monobehavior is created on said GameObject.

        * This tracker remotely controls the button, based on Settings passed into the control.

    * **WARNING:**  IF A DEBUGITEM DOES NOT HAVE AN OWNER IT WILL NOT BE REMOVED FROM THE DEBUG PANEL

    * **WARNING:** IF A TAB IS REMOVED, EVERYTHING IT CONTAINS WILL BE REMOVED AS WELL

## DebugItem.Settings

Settings are an optional parameter when creating a tab or button.

Currently, there are two settings:

* showDisabled: Display the control even if an owner is set.

* closeDebugOnClick: If the control is a button, enabling this will close the debug menu when the button is clicked.


# Available Debug Items

## Tab

Debug tabs are containers that hold other tabs and buttons to better organize long-lived DebugItems.

Example: `DebugPanel.Make.Tab(new("Tabname"))`

### Parameters

1. Header

2. (Optional) Settings

## Button

Buttons are controls that can be clicked on to conduct events.

Example: `DebugPanel.Make.Button(new("Button Name"), () => Debug.Log("Button Clicked"))`

Example: `DebugPanel.Make.Button(new("Button Name", tabObject.transform, gameObject), () => Debug.Log("Button Clicked"), new(showDisabled: true) )`

### Parameters

1. Header

2. Action
    
    * System.Action that will occur when the button is clicked. You can connect either a parameterless fucntio or a lambda expression to the button
    
    * Example: `() => Debug.Print("Button Clicked")`
    
    * Example: `foo`

3. (Optional) Settings
