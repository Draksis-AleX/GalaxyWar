using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPowerUp : PowerUp
{

    private void Start()
    {
        InfoPowerUp = "More Armor";
    }

    override public void SetPowerUp() {
        Debug.Log("Armor +50");
    }
}
