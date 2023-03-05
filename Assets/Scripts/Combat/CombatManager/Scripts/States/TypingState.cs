using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleStateMachine;
using ProjectKotoba.Gameplay.Typing;

public class TypingState : State
{
    [SerializeField]
    private AnimationState animationState;

    [SerializeField]
    private CurrentSkillManager currentSkillManager;

    #region プレイヤー変数
    [SerializeField]
    private Player player;

    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private PlayerSkillWordsUI playerWordsUI;

    private int[] possibleSelectedWords = { -1 };
    private int selectedWordIndex = -1;

    private int playerWordCurrentKKIndex = 0;
    private int playerWordKKCurrentAlphIndex = 0;
    private bool playerFinishWord = false;

    [SerializeField]
    SkillWordTemplate[] playerSkillWords;
    private string[][] playerWordsKKArray = new string[3][];
    private string[][] playerWordsAlphArray = new string[3][];
    #endregion


    #region 敵変数
    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private EnemySkillWordUI enemyWordsUI;

    private float enemyRemainingTime = 0f;
    private int enemyWordCurrentKKIndex = 0;
    private int enemyWordKKCurrentAlphIndex = 0;
    private bool enemyFinishWord = false;

    [SerializeField]
    SkillWordTemplate enemySkillWord;
    private string[] enemyWordKKArray = { " " };
    private string[] enemyWordAlphArray = { " " };
    #endregion


    private void Start()
    {
        ResetPlayerWordProgress();
        ResetEnemyWordProgress();
    }

    public override void EnterState()
    {
        //プレイヤー
        if (playerFinishWord)
        {
            playerFinishWord = false;

            ResetPlayerWordProgress();
        }

        //敵
        if (enemyFinishWord)
        {
            enemyFinishWord = false;

            ResetEnemyWordProgress();
        }

        base.EnterState();
    }

    public override State UpdateState()
    {
        #region プレイヤー
        if (player.IsAlive)
        {
            ReadPlayerInput(playerInput.GetInput());

            playerWordsUI.DisplaySkillWordsProgress(playerWordsKKArray, playerWordsAlphArray, selectedWordIndex, possibleSelectedWords, playerWordCurrentKKIndex, playerWordKKCurrentAlphIndex);

            if (playerFinishWord)
            {
                currentSkillManager.SetCurrentSkill(player, playerSkillWords[selectedWordIndex]);
                return animationState;
            }
        }
        #endregion

        #region 敵
        if (enemy.IsAlive)
        {
            enemyRemainingTime += Time.deltaTime;

            enemyRemainingTime = Mathf.Clamp(enemyRemainingTime, 0f, enemy.TypeCharSpeed);

            if (enemyRemainingTime == enemy.TypeCharSpeed)
            {
                enemyRemainingTime = 0;

                AddEnemyWordProgress();
            }

            enemyWordsUI.DisplaySkillWordProgress(enemyWordKKArray, enemyWordAlphArray, enemyWordCurrentKKIndex, enemyWordKKCurrentAlphIndex);

            if (enemyFinishWord)
            {
                currentSkillManager.SetCurrentSkill(enemy, enemySkillWord);
                return animationState;
            }
        }
        #endregion

        return base.UpdateState();
    }


    #region プレイヤー関数
    private void ReadPlayerInput(char inputChar)
    {
        switch (inputChar)
        {
            case '←':
                ResetPlayerWordProgress();
                break;
            case '□':
                //Pause
                break;
            default:
                if (inputChar != '×')
                {
                    if (selectedWordIndex == -1 || possibleSelectedWords.Length != 1)
                    {
                        SelectPlayerWord(inputChar);
                    }
                    else
                    {
                        AddPlayerWordProgress(inputChar);
                    }
                }
                break;
        }
    }

    private void SelectPlayerWord(char inputChar)
    {
        List<int> selectedWords = new List<int>();

        for (int i = 0; i < playerSkillWords.Length; i++)
        {
            if (inputChar == playerSkillWords[i].WordAlph[playerWordCurrentKKIndex][playerWordKKCurrentAlphIndex])
            {
                selectedWords.Add(i);
            }
        }

        if (selectedWords.Count >= 1)
        {
            possibleSelectedWords = selectedWords.ToArray();

            selectedWordIndex = possibleSelectedWords[0];

            AddPlayerWordProgress(inputChar);
        }
    }

    private void AddPlayerWordProgress(char inputChar)
    {
        string[] currentSkillWordAlph = playerWordsAlphArray[selectedWordIndex];

        KotobaGameplayTyping.AddWordProgress(inputChar, currentSkillWordAlph, ref playerWordCurrentKKIndex, ref playerWordKKCurrentAlphIndex, ref playerFinishWord);
    }

    private void ResetPlayerWordProgress()
    {
        selectedWordIndex = -1;
        possibleSelectedWords[0] = -1;

        playerWordCurrentKKIndex = 0;
        playerWordKKCurrentAlphIndex = 0;

        for (int i = 0; i < playerSkillWords.Length; i++)
        {
            playerWordsKKArray[i] = playerSkillWords[i].WordKK;
            playerWordsAlphArray[i] = playerSkillWords[i].WordAlph;
        }
    }
    #endregion


    #region 敵関数
    private void AddEnemyWordProgress()
    {
        KotobaGameplayTyping.AddWordProgress(enemyWordAlphArray, ref enemyWordCurrentKKIndex, ref enemyWordKKCurrentAlphIndex, ref enemyFinishWord);
    }

    public void ResetEnemyWordProgress()
    {
        enemyWordCurrentKKIndex = 0;
        enemyWordKKCurrentAlphIndex = 0;

        enemyWordKKArray = enemySkillWord.WordKK;
        enemyWordAlphArray = enemySkillWord.WordAlph;
    }
    #endregion
}
