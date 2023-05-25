using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : PowerUp
{
    private void Start()
    {
        InfoPowerUp = "More dmg";
    }

    override public void SetPowerUp()
    {
        Debug.Log("dmg +10"); //settarlo con un random 
    }
}
