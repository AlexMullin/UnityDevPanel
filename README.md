# INITIAL SETUP

**WARNING:** ERRORS WILL OCCUR IF YOU DO NOT DO THIS.

1. Place the Debug Panel Prefab in the scene's canvas
    1. For the best results, place the DebugPanel and canvas in a bootstrap scene or DontDestroyOnLoad object that is created before anything tries to use it.

# HOW TO USE

## Steps

1. After conducting the initial setup, open a script to one of your Game Objects that will appear in your scene.

2. The debug panel can be opened and closed by pressing **Ctrl + numpad0**

3. In the start function of your monobehavior, Place a button into the Debug Panel using **DebugPanel.Make.Button**

    * see Available Debug Items on which controls are available

4. When you want to test your fucntionality, open the panel and click the button

## DebugItem.Header

Headings for Debug Items. They contain the following information:

* Name of the Debug Item

* (Optional) Tab address of the buton
    * Exmaple `Enemies/HobGoblin/Skills`
    * If no arguement is given, the debug item will be placead in a top-level tab "Uncategorized".

* (Optional) Which GameObject Owns the button

    * When a control is created and this is points to another gameObject, a monobehavior is created on said GameObject.

        * This tracker remotely controls the button, Hiding it and Destroying it in tandem with the owner gameObject.

    * **WARNING:**  IF A DEBUGITEM DOES NOT HAVE AN OWNER IT WILL NOT BE REMOVED FROM THE DEBUG PANEL

# Available Debug Items

## Button

Buttons are controls that can be clicked on to conduct events.

Example: `DebugPanel.Make.Button(new("ButtonName"), () => Debug.Log("Button Clicked"))`

Example: `DebugPanel.Make.Button(new("Uppercut", "Enemies/HobGoblin/Skills", gameObject), () => Debug.Log("Button Clicked"))`

### Parameters

1. Header

2. Action
    
    * System.Action that will occur when the button is clicked. You can connect either a parameterless fucntio or a lambda expression to the button
    
    * Example: `() => Debug.Print("Button Clicked")`
    
    * Example: `foo`

3. (Optional) Settings
