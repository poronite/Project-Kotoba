using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(SkillWordTemplate))]
public class SkillWordInspector : Editor
{
    private int maxNumSkillCutscenes = 2;

    SkillWordTemplate skill;

    SerializedProperty skillName;    
    SerializedProperty description;
    SerializedProperty type;
    SerializedProperty attackStat;
    SerializedProperty healingPercentage;
    SerializedProperty numChar;
    SerializedProperty wordKK;
    SerializedProperty wordAlph;
    SerializedProperty skillCutscenes;
    

    private void OnEnable()
    {
        skill = (SkillWordTemplate)target;

        skillName = serializedObject.FindProperty("skillName");
        description = serializedObject.FindProperty("description");
        type = serializedObject.FindProperty("type");
        attackStat = serializedObject.FindProperty("attackStat");
        healingPercentage = serializedObject.FindProperty("healingPercentage");
        numChar = serializedObject.FindProperty("numChar");
        wordKK = serializedObject.FindProperty("wordKK");
        wordAlph = serializedObject.FindProperty("wordAlph");
        skillCutscenes = serializedObject.FindProperty("skillCutscenes");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //a
        EditorGUILayout.PropertyField(skillName, new GUIContent("Name: "), true);

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(description, new GUIContent("Description: "), true);

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(type, new GUIContent("Type: "), true);

        EditorGUILayout.Space();

        switch (skill.Type)
        {
            case WordType.Attack:
                EditorGUILayout.PropertyField(attackStat, new GUIContent("Attack: "), true);
                break;
            case WordType.Healing:
                EditorGUILayout.PropertyField(healingPercentage, new GUIContent("Healing (%): "), true);
                break;
            default:
                break;
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(numChar, new GUIContent("Number of Char (Kanji/Kana): "), true);

        EditorGUILayout.Space();

        int numCharLength = skill.NumChar;

        if (numCharLength < 0)
        {
            numCharLength = 0;
        }

        wordKK.arraySize = numCharLength;
        wordAlph.arraySize = numCharLength;

        for (int i = 0; i < numCharLength; i++)
        {
            SerializedProperty wordKKCurrentIndex = wordKK.GetArrayElementAtIndex(i);
            SerializedProperty wordAlphCurrentIndex = wordAlph.GetArrayElementAtIndex(i);

            EditorGUILayout.LabelField($"Char {i + 1}:");

            EditorGUILayout.PropertyField(wordKKCurrentIndex, new GUIContent("  Kanji/Kana: "), true);
            EditorGUILayout.PropertyField(wordAlphCurrentIndex, new GUIContent("  Alphabet: "), true);

            EditorGUILayout.Space();
        }

        EditorGUILayout.Space();

        skillCutscenes.arraySize = maxNumSkillCutscenes;

        EditorGUILayout.LabelField($"Cutscenes:");

        for (int i = 0; i < maxNumSkillCutscenes; i++)
        {
            SerializedProperty skillCutscene = skillCutscenes.GetArrayElementAtIndex(i);

            string character = "Character";

            switch (i)
            {
                case 0:
                    character = "Player";
                    break;
                case 1:
                    character = "Enemy";
                    break;
                default:
                    break;
            }

            EditorGUILayout.PropertyField(skillCutscene, new GUIContent($"  {character} Cutscene: "), true);            
        }

        serializedObject.ApplyModifiedProperties();

        EditorUtility.SetDirty(skill);
    }
}
