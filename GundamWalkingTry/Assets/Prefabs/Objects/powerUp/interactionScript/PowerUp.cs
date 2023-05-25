using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => "Press E";
    protected string InfoPowerUp;
    public bool Interact(Interactor interactor) {

        Debug.Log("take powerUp");
        this.gameObject.SetActive(false);

        interactor.takePowerUp(this);
        //mettere qualche effetto

        return true;  

    }

    abstract public void SetPowerUp();
}
