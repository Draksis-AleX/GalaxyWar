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
    [SerializeField] protected GameObject blurPanel;
    [SerializeField] protected TextMeshProUGUI title;
    //[SerializeField] protected TextMeshProUGUI info;
    [SerializeField] protected TextMeshProUGUI typeValue;
    [SerializeField] protected GameObject _UIImage;
    [SerializeField] protected GameObject _base;
    [SerializeField] protected GameObject rarityUi;


    protected int value;

    private void Awake()
    {
        value = Random.Range(1, 10) * 5;

        Material matCommon = Resources.Load<Material>("matirialCode/Common");
        Material matEpic = Resources.Load<Material>("matirialCode/Epic");
        Material matLegend = Resources.Load<Material>("matirialCode/Legend");

        Material[] _materials = _base.GetComponent<Renderer>().materials;

        if (value <= 20) _materials[2] = matCommon;
        else if (value > 20 && value <= 40) _materials[2] = matEpic;
        else if (value > 40 && value <= 50) _materials[2] = matLegend;
         

        _base.GetComponent<Renderer>().materials = _materials; 



    }

    public bool Interact(Interactor interactor) {

        Debug.Log("take powerUp");
        GameManager.Instance.gameData.tookPowerUp = true;
        this.gameObject.SetActive(false);
        interactor.takePowerUp(this);
        //mettere qualche effetto

        return true;  

    }

    public void Action()
    {
        SetPowerUp();
    }

    abstract public void SetPowerUp();

    public void SetPanel(string type)
    {
        title.text = titlePowerUp;
        //info.text = infoPowerUp;
        typeValue.text = type + " +" + value;
        _UIImage.GetComponent<Image>().sprite = this.iconaPowerUp;

        rarityUi.GetComponent<Image>().color = _base.GetComponent<Renderer>().materials[2].GetColor("_EmissionColor");

        panel.SetActive(true);
        blurPanel.GetComponent<Canvas>().worldCamera = CameraManager.Instance.gameObject.GetComponent<Camera>();
        blurPanel.SetActive(true);

        PowerUpManager.Instance.LockPowerUp();

    }
}
