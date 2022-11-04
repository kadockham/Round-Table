using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introcode : MonoBehaviour
{
    void OnEnable()
    {
         SceneManager.LoadScene("CutScene1", LoadSceneMode.Single);
         
    }
}
