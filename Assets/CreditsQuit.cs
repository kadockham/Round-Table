using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsQuit : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
        
    }
}
