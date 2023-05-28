using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healPawerUp : PowerUp
{
    
    private void Start()
    {
        titlePowerUp = "HEAL BONUS";
        infoPowerUp = "Hai trovato un PowerUp della salute, ora potrai subire più danni.";
        iconaPowerUp = Resources.Load<Sprite>("Image/heal-sprite");
    }

    override public void SetPowerUp() {

        int value = Random.Range(5, 50);
        SetPanel(value,"HP");
        
        //PlayerInputManager.setHeal(Random.Range(5, 50));
    }

    

}
