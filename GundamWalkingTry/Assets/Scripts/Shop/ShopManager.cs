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
    [SerializeField] TextMeshProUGUI myCoins;
    [SerializeField] Skill currentSkill;
    GameObject currentSkillGO;
    GameObject lastSkillGO;
    [SerializeField] List<int> ownedSkills;

    private void OnEnable()
    {
        updateMyCoins();
    }

    private void Start()
    {
        updateMyCoins();
    }

    public void updateDescription(GameObject invoker)
    {
        Debug.Log("updateDescription");
        currentSkillGO = invoker;
        if (lastSkillGO != null) { 
            if(lastSkillGO.GetComponent<Image>().color != Color.white) updateSkillColor(lastSkillGO, Color.black);
            Debug.Log(lastSkillGO.ToString());
        }
        Color selectColor = new Color(1f, 0, 0.2156863f);
        updateSkillColor(currentSkillGO, selectColor);
        lastSkillGO = currentSkillGO;
        currentSkill = invoker.transform.parent.gameObject.GetComponent<Skill>();
        title.text = currentSkill.getTitle();
        description.text = currentSkill.getDescription();
        price.text = currentSkill.getCost().ToString();
    }

    public void updateMyCoins()
    {
        myCoins.text = CoinManager.Instance.getCoins().ToString();
    }

    public void Buy()
    {
        if(currentSkill != null)
        {
            Debug.Log("Try Buy - Skill ID:" + currentSkill.getId());
            //--------------- Check if skills is unlocked ------------------------
            bool unlocked = false;
            if(currentSkill.getConnectedSkills().Length == 0)
            {
                unlocked = true;
            }
            else
            {
                foreach (int skillID in currentSkill.getConnectedSkills())
                {
                    if (ownedSkills.Contains(skillID))
                    {
                        unlocked = true;
                        break;
                    }
                }
            }

            //---------------- Check if alternative skill is already bought ---------------------------

            bool alternativeBought = false;
            if (currentSkill.getAlternativeSkill() != -1 && ownedSkills.Contains(currentSkill.getAlternativeSkill())) alternativeBought = true;
            else alternativeBought = false;

            //-------------------- Buy ----------------------------------------------
            
            if(CoinManager.Instance.getCoins() >= currentSkill.getCost() && unlocked && !currentSkill.isOwned() && !alternativeBought)
            {
                Debug.Log("Skill Bought - Skill ID:" + currentSkill.getId());
                currentSkill.getSkillEffect().Apply(PlayerManager.Instance.gameObject);
                ownedSkills.Add(currentSkill.getId());
                currentSkill.setOwned(true);
                updateSkillColor(currentSkillGO, Color.white);
                CoinManager.Instance.pay(currentSkill.getCost());
                updateMyCoins();
            }
        }
    }

    void updateSkillColor(GameObject target, Color color)
    {
        target.GetComponent<Image>().color = color;
    }

}


