using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] string title;
    [SerializeField] string description;
    [SerializeField] int cost;
    [SerializeField] int skillType;
    [SerializeField] int skillEffect;
    [SerializeField] int skillEffectValue;
    [SerializeField] int[] connected_skills;
    [SerializeField] Image icon;
    [SerializeField] bool owned;

    public Skill(int id, string title, string description, int cost, int skillType, int skillEffect, int skillEffectValue)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.cost = cost;
        this.skillType = skillType;
        this.skillEffect = skillEffect;
        this.skillEffectValue = skillEffectValue;
    }

    public int getId() { return this.id; }
    public string getTitle() { return this.title; }
    public string getDescription() { return this.description; }
    public int getCost() { return this.cost; }
    public int getSkillType() { return this.skillType; }
    public int getSkillEffect() { return this.skillEffect; }
    public int geSkillEffectValue() { return this.skillEffectValue; }

}
