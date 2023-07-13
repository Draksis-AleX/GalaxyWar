using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class InitScene : MonoBehaviour
{

    [SerializeField] protected Animator upperDoor;
    [SerializeField] protected Animator lowerDoor;
    WaveInfo waveInfo;

    public void Start()
    {
        Debug.Log("ChangeSceneCoroutine::Start");
        StartCoroutine("Init");
        ResetShield();
    }

    public IEnumerator Init()
    {
        //Debug.Log("Started Init Coroutine");
        
        upperDoor.Play("UpperClose");
        lowerDoor.Play("LowerClose");
        PlayerManager.Instance.gameObject.SetActive(true);
        yield return new WaitForSeconds(upperDoor.runtimeAnimatorController.animationClips[1].length);
        PlayerManager.Instance.gameObject.GetComponent<PlayerInput>().enabled = true;
        Debug.Log("Ended Init Coroutine");
    }

    void ResetShield()
    {
        PlayerManager.Instance.GetComponent<PlayerShieldManager>().reset();
    }

}
