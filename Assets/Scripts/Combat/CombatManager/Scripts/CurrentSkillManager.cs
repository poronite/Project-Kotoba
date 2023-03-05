using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSkillManager : MonoBehaviour
{
    private Character user;

    private SkillWordTemplate usedSkill;

    public Character User
    {
        get
        {
            return user;
        }
    }

    public SkillWordTemplate UsedSkill
    {
        get
        {
            return usedSkill;
        }
    }

    public void SetCurrentSkill(Character user, SkillWordTemplate usedSkill)
    {
        this.user = user;
        this.usedSkill = usedSkill;
    }
}
