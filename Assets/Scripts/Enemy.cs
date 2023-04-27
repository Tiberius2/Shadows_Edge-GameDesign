using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactible
{
    PlayerMonitoring playerMonitor;
    CharacterStats myStats;

    private new void Start()
    {
        playerMonitor = PlayerMonitoring.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        //attack the enemy
        CharacterCombat playerCombat = playerMonitor.player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);

        }
    }

}
