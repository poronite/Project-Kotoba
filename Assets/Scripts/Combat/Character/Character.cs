using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected CombatHPBarUI characterHPBar;

    [SerializeField]
    protected Character target;

    protected int maxHP = 0;

    protected int currentHP = 0;

    protected int attackStat = 0;

    private bool isAlive = true;

    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
    }


    public virtual void SetCharacterStats()
    {
        Debug.Log($"{gameObject.name} | 攻撃力：{attackStat} | 体力：{maxHP}");
    }

    public void Attack(int skillRawDamage)
    {
        int damage = attackStat + skillRawDamage;

        target.TakeDamage(damage);

        Debug.Log($"{gameObject.name}は攻撃した！");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name}は{damage}HPの攻撃をくらった！");

        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);

        if (currentHP == 0)
        {
            isAlive = false;
        }

        ChangeHPBarUI();
    }

    public void RecoverHP(float healingPercentage)
    {
        int recoveredHP = (int)(maxHP * healingPercentage / 100f);

        Debug.Log($"{gameObject.name}は{recoveredHP}HPを回復した！");

        currentHP = Mathf.Clamp(currentHP + recoveredHP, 0, maxHP);

        ChangeHPBarUI();
    }

    protected void ChangeHPBarUI(bool instantChangeFill = false)
    {
        float hpPercent = (float)currentHP / (float)maxHP;

        characterHPBar.ChangeHPBarFill(hpPercent, instantChangeFill);

        Debug.Log($"{gameObject.name}の現在の体力：{currentHP}HP");
    }
}
