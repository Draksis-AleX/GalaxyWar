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
            SceneManager.LoadScene(sceneName);
        }
    }

    private IEnumerator UnloadScene(int sceneIndex)
    {
        AsyncOperation asyncUnloadLevel = SceneManager.UnloadSceneAsync(sceneIndex);
        while (!asyncUnloadLevel.isDone)
            yield return null;
    }

}
