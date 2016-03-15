using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System;

public enum DamageType
{
    Hack,
    Pierce,
    Crush
}

public class Unit : MonoBehaviour
{
    public string unitName = "Unit";
    public int hp = 115;
    public int damage = 5;
    public DamageType damageType = DamageType.Hack;
    public int hackArmour = 35;
    public int pierceArmour = 10;
    public int crushArmour = 99;

    Guid id;
    Text nameText;
    Text hpText;
    Text damageText;
    Text damageTypeText;
    Text hackArmourText;
    Text pierceArmourText;
    Text crushArmourText;

    private BattleManager battleManager;

    // Use this for initialization
    void Start()
    {
        id = Guid.NewGuid();

        Text[] textComponents = GetComponentsInChildren<Text>();
        nameText = textComponents.FirstOrDefault(x=> x.name == "Name");
        hpText = textComponents.FirstOrDefault(x => x.name == "HP");
        damageText = textComponents.FirstOrDefault(x => x.name == "Damage");
        damageTypeText = textComponents.FirstOrDefault(x => x.name == "Damage Type");
        hackArmourText = textComponents.FirstOrDefault(x => x.name == "Hack Armour");
        pierceArmourText = textComponents.FirstOrDefault(x => x.name == "Pierce Armour");
        crushArmourText = textComponents.FirstOrDefault(x => x.name == "Crush Armour");

        battleManager = GameObject.FindObjectOfType<BattleManager>();
        battleManager.RegisterUnit(this);
    }

    // Update is called once per frame
    void Update()
    {


        UpdateUI();
    }

    void UpdateUI()
    {
        nameText.text = unitName;
        hpText.text = hp.ToString();
        damageText.text = damage.ToString();

        switch(damageType)
        {
            case DamageType.Hack:
                damageTypeText.text = "Hack";
                break;
            case DamageType.Pierce:
                damageTypeText.text = "Pierce";
                break;
            case DamageType.Crush:
                damageTypeText.text = "Crush";
                break;
        }

        hackArmourText.text = hackArmour.ToString() + '%';
        pierceArmourText.text = pierceArmour.ToString() + '%';
        crushArmourText.text = crushArmour.ToString() + '%';
    }

    public void Damage(int dmg, DamageType type)
    {
        float damagePercentage;

        switch(type)
        {
            case DamageType.Hack:
                damagePercentage = (1f - (float)hackArmour / 100f);
                break;
            case DamageType.Pierce:
                damagePercentage = (1f - (float)pierceArmour / 100f);
                break;
            case DamageType.Crush:
                damagePercentage = (1f - (float)crushArmour / 100f);
                break;
            default:
                damagePercentage = 0f;
                break;
        }

        int actualDamage = (int)((float)dmg * damagePercentage);
        this.hp -= actualDamage;
    }
}