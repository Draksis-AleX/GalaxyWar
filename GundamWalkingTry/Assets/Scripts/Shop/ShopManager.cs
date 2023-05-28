using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI price;

    public void updateDescription(GameObject invoker)
    {
        Debug.Log("updateDescription");
        title.text = invoker.transform.parent.GetComponent<Skill>().getTitle();
        description.text = invoker.transform.parent.GetComponent<Skill>().getDescription();
        price.text = invoker.transform.parent.GetComponent<Skill>().getCost().ToString();
    }
}
