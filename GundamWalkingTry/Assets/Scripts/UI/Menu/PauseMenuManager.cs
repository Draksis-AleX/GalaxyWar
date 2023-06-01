using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private static PauseMenuManager _instance;

    public bool active => false;

    public static PauseMenuManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PauseMenuManager>();
                if (_instance == null) Debug.LogError("No PauseMenu in scene");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public void Pause()
    {
        Debug.Log("Pause");
        this.gameObject.SetActive(true);
        Time.timeScale = 0f;
        PlayerManager.Instance.GetComponent<PlayerInput>().enabled = false;
    }

    public void Resume()
    {
        Debug.Log("Resume");
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
        PlayerManager.Instance.GetComponent<PlayerInput>().enabled = true;
        WindowManager.Instance.setDiplayEmpty(true);
    }

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        PlayerManager.Instance.StopAllCoroutines();
        PlayerManager.Instance.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Escape(InputAction.CallbackContext context)
    {

        Debug.Log(WindowManager.Instance.canShow() + " " + this.gameObject.activeSelf + " " + context.started);

        if (WindowManager.Instance.canShow() && this.gameObject.activeSelf == false && context.started)
        {
            WindowManager.Instance.setDiplayEmpty(false);
            Pause();
        }
        else if (this.gameObject.activeSelf == true && context.started) {
            //WindowManager.Instance.setDiplayEmpty(true);
            Resume();
        }
        


    }
}
