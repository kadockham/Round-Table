using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Dialogues List
    public List<string> dialogues;
    //Index on Dialogue
    private int index;
    //Charachter Index
    private int charIndex;

    private void Togglewindow(bool show){
        window.SetActive(true);
    }

    //Start Dialogue
    public void StartDialogue(){
        //Show the window
        window.SetActive(true);
        //hide the indicator
        //start index at zero
        //start writing
    }
    //End Dialogue
    public void EndDialogue(){
        //Hide the window

    }
    //Writing Logic
    IEnumerator Writing(){
        //Write the character
        //increase the charachter index
        //wait x seconds
        //restart the same process
    }

}
