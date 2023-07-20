using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialButtonScripts : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject des;
    [SerializeField] GameObject menuToHide;
    [SerializeField] GameObject menuTutorial;



    public void ShopButton() {

        string descrizione = "Allora praticamente se compri devi pagare se non hai" +
                               " soldi non puoi comprare, non siamo a napoli quindi non  puoi rubare";
        //caricare immaggini
        ShowTutorial("SHOP", descrizione);
    }

    public void GamePlayButton()
    {
        string descrizione = "Impara a giocare nabbo";
        ShowTutorial("GAMEPLAY", descrizione);
    }
    public void PUButton()
    {
        string descrizione = "Se li prendi sei piuù forte";
        ShowTutorial("PUWERUPS", descrizione);
    }
    public void CoinButton()
    {
        string descrizione = "Piu ne hai più sei felice ";
        ShowTutorial("COIN", descrizione);
    }

    public void ScoreButton()
    {
        string descrizione = "Più ne fai più sei felice";
        ShowTutorial("SCORE", descrizione);
    }
    public void EnemyButton()
    {
        string descrizione = "quello blu si chima IlKiller";
        ShowTutorial("ENEMY", descrizione);
    }
    public void RunHistory()
    {
        string descrizione = "Se vuoi vedere che hai fatto nell vita guardalo ";
        ShowTutorial("RUN HISTORY", descrizione);
    }


    public void ShowTutorial(string titleName , string descrizione) {
        title.gameObject.GetComponent<TextMeshProUGUI>().text = titleName;
        des.gameObject.GetComponent<TextMeshProUGUI>().text = descrizione;
        menuToHide.SetActive(false);
        menuTutorial.SetActive(true);

        //lista per immagine circolare 
        


    }

}
