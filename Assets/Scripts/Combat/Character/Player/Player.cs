using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Start()
    {
        SetCharacterStats();
    }

    public override void SetCharacterStats()
    {
        maxHP = 100;

        currentHP = maxHP;

        ChangeHPBarUI(true);

        attackStat = 10;

        base.SetCharacterStats();
    }
}
