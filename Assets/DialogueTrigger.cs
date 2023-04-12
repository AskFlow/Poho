using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public DialogueManager dialogueManager;

    public UnityEvent action;

    private bool isEntered = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter)) 
        {
            dialogueManager.DisplayNextSentence();
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
