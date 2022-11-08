using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerTest : MonoBehaviour
{   //BELOW IS CALLING THE OTHER SCRIPT. NEED TO CHANGE IF CHANGE SCRIPT NAME
    public DialogueTest dialogueScript;
    private bool playerDetected;
    //Detect trigger with player
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //If we triggered the player, enable playerdetected and show indicator
        if(collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        //if we lost trigger with the player, disable playerdetected and hide indicator
         if(collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }
    //while detected if we interact start the dialgoue
    private void Update() {
        if(playerDetected && Input.GetKeyDown(KeyCode.E)){
            dialogueScript.StartDialogue();
        }
        
    }
}
