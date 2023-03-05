using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAction : MonoBehaviour
{
    [SerializeField]
    private CurrentSkillManager currentSkillManager;

    private void OnEnable()
    {
        switch (gameObject.name)
        {
            case "Attack":
                currentSkillManager.User.Attack(currentSkillManager.UsedSkill.AttackStat);
                break;
            case "Defense":
                //これ綺麗ではない
                FindObjectOfType<TypingState>().ResetEnemyWordProgress();
                break;
            case "Healing":
                currentSkillManager.User.RecoverHP(currentSkillManager.UsedSkill.HealingPercentage);
                break;
            default:
                break;
        }
    }
}
