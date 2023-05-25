using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPawerUp : PowerUp
{
    private void Start()
    {
        InfoPowerUp = "More HP";
    }

    override public void SetPowerUp() {
        Debug.Log("Vita +50");
    }

}
