using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator upperDoor;
    [SerializeField] private Animator lowerDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("PortaArena") && GameManager.Instance.completedArena == false) return;
        if (this.CompareTag("PortaMagazzino") && GameManager.Instance.tookPowerUp == true) return;
        if (other.CompareTag("Player"))
            {
                upperDoor.SetBool("Open", true);
                lowerDoor.SetBool("Open", true);
                Debug.Log("Trigger Door Enter");
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("PortaArena") && GameManager.Instance.completedArena == false) return;
        if (this.CompareTag("PortaMagazzino") && GameManager.Instance.tookPowerUp == true) return;
        if (other.CompareTag("Player"))
            {
                upperDoor.SetBool("Open", false);
                lowerDoor.SetBool("Open", false);
                Debug.Log("Trigger Door Exit");
            }        
    }

}
