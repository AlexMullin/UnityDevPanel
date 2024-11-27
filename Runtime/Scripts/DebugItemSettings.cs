using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevPanel
{
    /// <summary>
    /// Settings to pass into a newly created debugButton for controlling its behavior.
    /// </summary>
    [Obsolete("Class moved to subclass of DebugItem. Use as DebugItem.Settings", true)]
    public class DebugItemSettings
    {
        public DebugItemSettings(bool hideOnDisable = true, bool closeDebugOnClick = false)
        {
            HideOnDisable = hideOnDisable;
            CloseDebugOnClick = closeDebugOnClick;

        }

        public readonly bool HideOnDisable;
        public readonly bool CloseDebugOnClick;
    }
}

