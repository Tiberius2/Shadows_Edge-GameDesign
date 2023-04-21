using UnityEngine;


public class PlayerStats : CharacterStats
{
    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if(oldItem != null)
        {
            armor.RemoveModifier(newItem.armorModifier);
            damage.RemoveModifier(newItem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        // kill the player in some way
        PlayerMonitoring.instance.KillPlayer();
    }
}
