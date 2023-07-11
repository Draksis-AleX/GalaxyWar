using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = false;
            PlayerManager.Instance.gameObject.SetActive(false);
            //StartCoroutine(UnloadScene(SceneManager.GetActiveScene().buildIndex));
            if (sceneName.Length > 0) SceneManager.LoadScene(sceneName);
            else SceneManager.LoadScene(GameManager.Instance.nextScene);
        }
    }

    private IEnumerator UnloadScene(int sceneIndex)
    {
        AsyncOperation asyncUnloadLevel = SceneManager.UnloadSceneAsync(sceneIndex);
        while (!asyncUnloadLevel.isDone)
            yield return null;
    }

}
