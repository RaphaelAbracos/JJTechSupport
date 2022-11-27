using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

     public void QuitGame(){
        Application.Quit();
    }

    public void Resume()
    {
        SceneManager.LoadScene(1);
    }

}
