using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindowManager : MonoBehaviour
{
    public static WindowManager _instance;

    bool DisplayEmpty;

    public static WindowManager Instance
       {
         get
            {
              if (_instance == null)
              {
                  _instance = GameObject.FindObjectOfType<WindowManager>();
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
        else GameObject.Destroy(this.gameObject);

        DisplayEmpty = true;
     }

    private void Update()
    {

        Debug.Log("pause update fuori");

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseMenuManager.Instance.Escape();
            Debug.Log("pause update dentro");
        }
       
    }

    public void setDiplayEmpty(bool empty) { DisplayEmpty = empty; }

    public bool canShow() {
        if (DisplayEmpty) return true;
        return false;
    }
     
 }
