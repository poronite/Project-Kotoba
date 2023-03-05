using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private float typeCharSpeed = 1.0f;

    public float TypeCharSpeed
    {
        get
        {
            return typeCharSpeed;
        }
    }

    private void Start()
    {
        SetCharacterStats();
    }

    public override void SetCharacterStats()
    {
        typeCharSpeed = 0.5f;

        maxHP = 100;

        currentHP = maxHP;

        ChangeHPBarUI(true);

        attackStat = 8;

        base.SetCharacterStats();
    }
}
