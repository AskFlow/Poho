using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] private InputActionAsset inputActions;

    public DialogueManager dialogueManager;

    public UnityEvent action;

    private bool isEntered = false;

    public void Start()
    {
        inputActions.Enable();

    }


    private void Update()
    {
        if (inputActions.FindAction("Use").triggered) 
        {

            dialogueManager.DisplayNextSentence();
            Debug.Log("wag");
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        action?.Invoke();
    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !isEntered)
        {
            isEntered = true;
            this.TriggerDialogue();

        }
    }


}
