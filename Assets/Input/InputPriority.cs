using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputPriority : MonoBehaviour
{
    public Button[] buttons;
    public int defaultSelectedIndex = 0;

    private int selected = -1;
    private int previousSelected = -1;

    private void Start()
    {
        if (buttons.Length > 0)
        {
            selected = defaultSelectedIndex;
            buttons[selected].Select();
            previousSelected = selected;
        }
    }

    public void SetSelectedButton(BaseEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(eventData.selectedObject);
        var button = eventData.selectedObject.GetComponent<Button>();
        if (button != null)
        {
            selected = System.Array.IndexOf(buttons, button);
        }
    }

    public void ClearSelectedButton(BaseEventData eventData)
    {
        selected = -1;
    }

    private void Update()
    {
        if (selected != -1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                int index = (selected + 1) % buttons.Length;
                selected = index;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                int index = (selected - 1 + buttons.Length) % buttons.Length;
                selected = index;
            }

            if (selected != previousSelected)
            {
                buttons[selected].Select();
                previousSelected = selected;
            }
        }
    }
}

