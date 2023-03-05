using System.Text;
using UnityEngine;
using TMPro;
using ProjectKotoba.UI.Text;

public class PlayerSkillWordsUI : MonoBehaviour
{
    //攻撃の言葉のUI
    [SerializeField]
    private SkillWordUI attackWordUI;

    //防御の言葉のUI
    [SerializeField]
    private SkillWordUI defenseWordUI;

    //回復の言葉のUI
    [SerializeField]
    private SkillWordUI healingWordUI;
    
    
    //言葉はどこまで打っているのか表示する。
    public void DisplaySkillWordsProgress(string[][] skillWordsKK, string[][] skillWordsAlph, int selectedWordIndex, int[] possibleSelectedWords, int wordKKProgressIndex, int wordAlphProgressIndex)
    {
        int secondPossibleSelectionWord = -1;
        int thirdPossibleSelectionWord = -1;

        for (int i = 0; i < possibleSelectedWords.Length; i++)
        {
            switch (i)
            {
                case 1:
                    secondPossibleSelectionWord = possibleSelectedWords[i];
                    break;
                case 2:
                    thirdPossibleSelectionWord = possibleSelectedWords[i];
                    break;
                default:
                    break;
            }
        }

        //三つの言葉のUIだからループは３回
        for (int wordIndex = 0; wordIndex < skillWordsKK.Length; wordIndex++)
        {
            //短くて書きやすい名前の変数に各回の言葉の文字を保存する
            string[] wordKK = skillWordsKK[wordIndex];
            string[] wordAlph = skillWordsAlph[wordIndex];

            //漢字仮名版の言葉は i = 0 | アルファベット版の言葉は i = 1
            StringBuilder[] wordBuilder = { new StringBuilder(), new StringBuilder() };            

            //もし言葉は選択されていたら打っている文字までに何もしない、その文字の後だけに透明を適用する
            if (wordIndex == selectedWordIndex || wordIndex == secondPossibleSelectionWord || wordIndex == thirdPossibleSelectionWord)
            {
                wordBuilder = KotobaUIText.SkillWordProgress(true, wordKK, wordAlph, wordKKProgressIndex, wordAlphProgressIndex);
            }
            else //言葉は選択されてない場合は言葉全体に透明を適用する
            {
                wordBuilder = KotobaUIText.SkillWordProgress(false, wordKK, wordAlph, wordKKProgressIndex, wordAlphProgressIndex);
            }

            //言葉をUIに書き出す
            switch (wordIndex)
            {
                case 0:
                    attackWordUI.SetSkillWordTextUI(wordBuilder);
                    break;
                case 1:
                    defenseWordUI.SetSkillWordTextUI(wordBuilder);
                    break;
                case 2:
                    healingWordUI.SetSkillWordTextUI(wordBuilder);
                    break;
                default:
                    break;
            }
        }
    }
}
