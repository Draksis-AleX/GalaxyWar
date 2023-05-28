using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPowerUp : PowerUp
{
    private void Start()
    {
        titlePowerUp = "BULLET BONUS";
        infoPowerUp = "Hai trovato un PowerUp per i tuoi proiettili, ora potrai infliggere più danni ai tuoi nemici.";
        iconaPowerUp = Resources.Load<Sprite>("Image/bullet-sprite");
    }

    override public void SetPowerUp()
    {
        int value = Random.Range(5, 50);
        SetPanel(value, "Dmg");
    }


}
