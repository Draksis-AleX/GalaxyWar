using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public abstract class PowerUp : MonoBehaviour, IInteractable
{
    public string InteractionPrompt => "Press E";
    protected string infoPowerUp;
    protected string titlePowerUp;
    protected Sprite iconaPowerUp;
    [SerializeField] protected GameObject panel;
    [SerializeField] protected TextMeshProUGUI title;
    //[SerializeField] protected TextMeshProUGUI info;
    [SerializeField] protected TextMeshProUGUI typeValue;
    [SerializeField] protected GameObject _UIImage;


    [SerializeField] 

    public bool Interact(Interactor interactor) {

        Debug.Log("take powerUp");
        this.gameObject.SetActive(false);
        interactor.takePowerUp(this);
        //mettere qualche effetto

        return true;  

    }

    abstract public void SetPowerUp();

    public void SetPanel(int value, string type)
    {
        title.text = titlePowerUp;
        //info.text = infoPowerUp;
        typeValue.text = type + " +" + value;
        _UIImage.GetComponent<Image>().sprite = this.iconaPowerUp;
        panel.SetActive(true);
    }
}
