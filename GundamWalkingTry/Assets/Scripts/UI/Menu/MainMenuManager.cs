using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void PlayGame(){

        GameData d  = new GameData();

        if (d.loadData("game") == null) {
            SceneManager.LoadScene(sceneName);
        }
        else {

            d = JsonUtility.FromJson<GameData>(d.loadData("game"));
            SceneManager.LoadScene(d.scene);

        } 
        
    }
    public void NewGame()
    {
        string path = Application.persistentDataPath;
        if (Directory.Exists(path)) Directory.Delete(path, true);
        Directory.CreateDirectory(path);
        SceneManager.LoadScene(sceneName);
    }


    public void Quitgame(){
        Application.Quit();
    }
    
}
