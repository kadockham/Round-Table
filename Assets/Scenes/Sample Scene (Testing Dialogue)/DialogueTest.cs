using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For UI of dialogue box
using TMPro;

public class DialogueTest : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Text Component
    public TMP_Text dialogueText;
    //Dialogues List
    public List<string> dialogues;
    //Writing speed
    public float writingSpeed;
    //Index on Dialogue
    private int index;
    //Charachter Index
    private int charIndex;
    //Started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;

    private void Awake() {
    ToggleIndicator(false);    
    ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue()
    {
        if(started) return;

        //Boolean to indicate that we have started
        started = true;
        //Show the window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //Start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //Reset the character index
        charIndex = 0;
        //Clear the Dialogue Component Text
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }

    //End Dialogue
    public void EndDialogue()
    {
        //Hide the window
        ToggleWindow(false);
        
    }
    //Writing Logic
    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
        //Write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the charachter index
        charIndex++;
        //Make sure you have reached the end of the sentence
        if(charIndex < currentDialogue.Length)
        {
            //wait x seconds
            yield return new WaitForSeconds(writingSpeed);
            //restart the same process
            StartCoroutine(Writing());
        }
        else{//End this sentence and wait for the next one
            waitForNext = true;
        }  
    }

    private void Update()
    {
        if (!started) return;
        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            if(index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                //End Fialogue
                EndDialogue();
            }
            
        }
    }
}
