using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene(firstLevel1);
    }

    public void OpenOptions(){
        
    }

    public void CloseOptions(){
        
    }
    //doesnt work in editor, works when build game
    public void QuitGame(){
        Application.Quit();
        
    }

    
}
