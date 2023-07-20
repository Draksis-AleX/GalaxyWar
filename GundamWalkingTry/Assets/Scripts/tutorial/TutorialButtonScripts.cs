using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialButtonScripts : MonoBehaviour 
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject des;
    [SerializeField] GameObject tutorialImage;
    [SerializeField] GameObject arrowNext;
    [SerializeField] GameObject arrowPrev;
    [SerializeField] GameObject menuToHide;
    [SerializeField] GameObject menuTutorial;

    [SerializeField] List<Sprite> Showimages;

    int index;

    private void Start()
    {
        //images = new List<Sprite>();
    }


    public void ShopButton() {

        List<Sprite> tutorialImages = new List<Sprite>();

        Debug.Log("" + Resources.Load("TutorialImage/Shop/TutorialOutsideShop").GetType());

        tutorialImages.Add(((Texture2D)Resources.Load("TutorialImage/Shop/TutorialOutsideShop")).ConvertToSprite());
        tutorialImages.Add(((Texture2D)Resources.Load("TutorialImage/Shop/TutorialShopMenu")).ConvertToSprite());

        string descrizione = "To open the Shop Tab interact with the Shop Station in the starting hangar pressing E \n"

                                + "If you have enough money you can buy any unlocked skill you want.This Skills are PERMANENT (Unless you start a New Game).\n\n"

                                       + "Look at the second screen for a Shop Tab description.\n";

        ShowTutorial("SHOP", descrizione , true , tutorialImages);
    }

    public void GamePlayButton()
    {
        List<Sprite> tutorialImages = new List<Sprite>();

        Debug.Log("" + Resources.Load("TutorialImage/Shop/TutorialOutsideShop").GetType());

        tutorialImages.Add(((Texture2D)Resources.Load("TutorialImage/GAMEPLAY/TutorialHUD")).ConvertToSprite());
        tutorialImages.Add(((Texture2D)Resources.Load("TutorialImage/GAMEPLAY/TutorialMove")).ConvertToSprite());
        tutorialImages.Add(((Texture2D)Resources.Load("TutorialImage/GAMEPLAY/TutorialAim")).ConvertToSprite());
        tutorialImages.Add(((Texture2D)Resources.Load("TutorialImage/GAMEPLAY/TutorialShoot")).ConvertToSprite());

        string descrizione = "Your HUD is composed by:"
                                + "- Your Health(RED)\n- Your Shield(BLU)\n- Your Coins\n\n" +

                                "To Move the Player use the WASD keys(you can switch to arrow keys in control settings)\n\n" +

                                "To aim hold the Right Button of the Mouse\n\n" +

                                "To Shoot click the Left Button of the Mouse";

        ShowTutorial("GAMEPLAY", descrizione, true, tutorialImages);
    }
    public void PUButton()
    {
        string descrizione = "Se li prendi sei piuù forte";
        //ShowTutorial("PUWERUPS", descrizione , true);
    }
    public void CoinButton()
    {
        string descrizione = "Piu ne hai più sei felice ";
        //ShowTutorial("COINS", descrizione, true);
    }

    public void ScoreButton()
    {
        string descrizione = "Più ne fai più sei felice";
        //ShowTutorial("SCORE", descrizione, true);
    }
    public void EnemyButton()
    {
        string descrizione = "quello blu si chima IlKiller";
        //ShowTutorial("ENEMIES", descrizione, true);
    }
    public void RunHistory()
    {
        string descrizione = "Se vuoi vedere che hai fatto nell vita guardalo ";
        //ShowTutorial("RUN RANKING", descrizione, true);
    }


    public void ShowTutorial(string titleName , string descrizione , bool showArrows , List<Sprite> images) {
        title.gameObject.GetComponent<TextMeshProUGUI>().text = titleName;
        des.gameObject.GetComponent<TextMeshProUGUI>().text = descrizione;

        Showimages = images;

        index = 0;

        tutorialImage.gameObject.GetComponent<Image>().sprite = Showimages[index];

        arrowNext.gameObject.SetActive(showArrows);
        arrowPrev.gameObject.SetActive(showArrows);

        menuToHide.SetActive(false);
        menuTutorial.SetActive(true);
        
    }

    public void NextButton()
    {
        Debug.Log("index" + index + " count:" + Showimages.Count);
        index++;
        tutorialImage.gameObject.GetComponent<Image>().sprite = Showimages[Mathf.Abs(index) % Showimages.Count];
    }

    public void PrevButton()
    {
        index--;
        tutorialImage.gameObject.GetComponent<Image>().sprite = Showimages[Mathf.Abs(index) % Showimages.Count];
    }

}
