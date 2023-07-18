using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject deathUI;
    GameObject blur;

    public void Die()
    {
        deathUI.SetActive(true);
        blur = GameObject.Find("Blur");
        blur.GetComponent<Canvas>().worldCamera = CameraManager.Instance.gameObject.GetComponent<Camera>();
        blur.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void Restart()
    {
        blur.GetComponent<CanvasGroup>().alpha = 0;
        GameManager.Instance.runRestart();
        deathUI.SetActive(false);
    }

    public void Quit()
    {
        blur.GetComponent<CanvasGroup>().alpha = 0;
        GameManager.Instance.runRestart(false);
        SceneManager.LoadScene("Menu");
        PlayerManager.Instance.StopAllCoroutines();
        PlayerManager.Instance.gameObject.SetActive(false);
        deathUI.SetActive(false);
        WindowManager.Instance.setDiplayEmpty(false);
    }
}
