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
            SceneManager.LoadScene(sceneName);
        }
    }

}
