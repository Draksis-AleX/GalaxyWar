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
    [SerializeField] Skill currentSkill;
    [SerializeField] List<int> ownedSkills;

    public void updateDescription(GameObject invoker)
    {
        Debug.Log("updateDescription");
        currentSkill = invoker.transform.parent.gameObject.GetComponent<Skill>();
        title.text = currentSkill.getTitle();
        description.text = currentSkill.getDescription();
        price.text = currentSkill.getCost().ToString();
    }

    public void Buy()
    {
        if(currentSkill != null)
        {
            Debug.Log("Try Buy - Skill ID:" + currentSkill.getId());
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
            
            if(CoinManager.Instance.getCoins() >= currentSkill.getCost() && unlocked && !currentSkill.isOwned())
            {
                Debug.Log("Skill Bought - Skill ID:" + currentSkill.getId());
                currentSkill.getSkillEffect().Apply(PlayerManager.Instance.gameObject);
                ownedSkills.Add(currentSkill.getId());
                currentSkill.setOwned(true);
            }
        }
    }
}
