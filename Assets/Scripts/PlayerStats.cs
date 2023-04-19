using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;


    public int damage;
    public int armor;

    public Text damageText;
    public Text armorText;

    private void Awake()
    {
        Instance = this;
    }
    public void IncreaseDamage(int value)
    {
        Debug.Log(damage);
        damage += value;
        Debug.Log(damage);
        damageText.text = $"Damage: {damage}";
    }

    public void IncreaseArmor(int value)
    {
        armor += value;
        armorText.text = $"Armor: {armor}";
    }
}
