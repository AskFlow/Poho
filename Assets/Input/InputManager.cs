using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] private Keybindings keybindings;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public KeyCode GetKeyForAction(KeyBindingActions keyBindingAction)
    {
        foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if(keybindingCheck.keyBindingAction == keyBindingAction)
            {
                return keybindingCheck.keyCode;
            }
        }

        return KeyCode.None;
    }

    public bool GetKeyDown(KeyBindingActions key) 
    {
        foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if (keybindingCheck.keyBindingAction == key)
            {
                return Input.GetKeyDown(keybindingCheck.keyCode);
            }
        }
        return false;
    }

    public bool GetKeyUp(KeyBindingActions key)
    {
        foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if (keybindingCheck.keyBindingAction == key)
            {
                return Input.GetKeyUp(keybindingCheck.keyCode);
            }
        }
        return false;
    }

    public bool GetKey(KeyBindingActions key)
    {
        foreach (Keybindings.KeybindingCheck keybindingCheck in keybindings.keybindingChecks)
        {
            if (keybindingCheck.keyBindingAction == key)
            {
                return Input.GetKey(keybindingCheck.keyCode);
            }
        }
        return false;
    }
}
