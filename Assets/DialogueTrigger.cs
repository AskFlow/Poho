using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public DialogueManager dialogueManager;

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
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.TriggerDialogue();
        }
    }


}
