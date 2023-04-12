using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class Keybindings : ScriptableObject
{
    [System.Serializable]
    public class KeybindingCheck
    {
        public KeyBindingActions keyBindingAction;
        public KeyCode keyCode;
    }
    public KeybindingCheck[] keybindingChecks;
}
