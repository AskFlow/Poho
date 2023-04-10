using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;


public class BindingKey : MonoBehaviour
{

    private PlayerMovement playerControls;
    public TMP_Text jumpKeyText;
    public TMP_Text forwardKeyText;
    public TMP_Text backwardKeyText;
    public TMP_Text attackKeyText;
    public TMP_Text useKeyText;
    public Button jumpKeyButton;
    public Button forwardKeyButton;
    public Button backwardKeyButton;
    public Button attackKeyButton;
    public Button useKeyButton;


    private KeyCode currentKey = KeyCode.None;

    void Awake()
    {
        playerControls = new PlayerMovement();
    }
    void Start()
    {
        SetKey();
    }
    void Update()
    {
    }

    public void ChangeKey()
    {
        bool inputDown = false;

        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        string inputName = string.Empty;
        if (buttonName == "JumpButton")
        {

            if (!inputDown)
            {
                if (Input.anyKeyDown) 
                {
                    Debug.Log("caca");
                    inputName = Input.inputString.ToString().ToUpper();

                }

                //else if (inputName.Length > 0 )
                //{
                //    Debug.Log("passer");
                //    inputDown = true;
                //}
            }
            playerControls.jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), inputName);
        }
        else if (buttonName == "ForwardButton")
        {
            while (!inputDown)
            {
                inputName = Input.inputString.ToString().ToUpper();
                if (inputName.Length > 0)
                {
                    inputDown = true;
                }
            }
            playerControls.jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), inputName);
            }
        else if (buttonName == "BackwardButton")
        {
            while (!inputDown)
            {
                 inputName = Input.inputString.ToString().ToUpper();
                if (inputName.Length > 0)
                {
                    inputDown = true;
                }
            }
            playerControls.backwardKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), inputName);
        }
        else if (buttonName == "AttackButton")
        {
            while (!inputDown)
            {
                 inputName = Input.inputString.ToString().ToUpper();
                if (inputName.Length > 0)
                {
                    inputDown = true;
                }
            }
            playerControls.attackKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), inputName);
        }
        else if (buttonName == "UseButton")
        {
            while (!inputDown)
            {
                 inputName = Input.inputString.ToString().ToUpper();
                if (inputName.Length > 0)
                {
                    inputDown = true;
                }
            }
            playerControls.useKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), inputName);
        }
        SetKey();

    }

    public void SetKey()
    {
        jumpKeyText.text = playerControls.jumpKey.ToString();
        forwardKeyText.text = playerControls.backwardKey.ToString();
        backwardKeyText.text = playerControls.attackKey.ToString();
        attackKeyText.text = playerControls.forwardKey.ToString();
        attackKeyText.text = playerControls.useKey.ToString();
    }
}
