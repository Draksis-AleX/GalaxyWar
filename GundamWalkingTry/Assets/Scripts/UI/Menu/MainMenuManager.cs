using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void PlayGame(){
        SceneManager.LoadScene(sceneName);
    }

    public void Quitgame(){
        Application.Quit();
    }
    
}
