using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public enum WordType
{
    Attack,
    Defense,
    Healing
}

[CreateAssetMenu(fileName = "New Skill Word", menuName = "Project Kotoba/Create new Skill Word")]
public class SkillWordTemplate : ScriptableObject
{
    [SerializeField]
    private string skillName;

    [SerializeField, TextArea(3, 10)]
    private string description;

    [SerializeField]
    private WordType type;

    [SerializeField]
    private int attackStat = 10;

    [SerializeField, Range(0f, 100.0f)]
    private float healingPercentage = 30.0f;

    [SerializeField]
    private int numChar;

    [SerializeField]
    private string[] wordKK;

    [SerializeField]
    private string[] wordAlph;

    [SerializeField]
    private TimelineAsset[] skillCutscenes;


    public string SkillName { get { return skillName; } }

    public string Description { get { return description; } }

    public WordType Type { get { return type; } }

    public int AttackStat { get { return attackStat; } }

    public float HealingPercentage { get { return healingPercentage; } }

    public int NumChar { get { return numChar; } }

    public string[] WordKK { get { return wordKK; } }

    public string[] WordAlph { get { return wordAlph; } }

    public TimelineAsset[] SkillCutscenes { get { return skillCutscenes; } }
}
