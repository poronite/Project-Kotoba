using System.Text;
using UnityEngine;
using ProjectKotoba.UI.Text;

public class EnemySkillWordUI : MonoBehaviour
{
    [SerializeField]
    private SkillWordUI enemyAttackWordUI;

    public void DisplaySkillWordProgress(string[] wordKK, string[] wordAlph, int wordKKProgressIndex, int wordAlphProgressIndex)
    {
        //漢字仮名版の言葉は i = 0 | アルファベット版の言葉は i = 1
        StringBuilder[] wordBuilder = new StringBuilder[2];

        wordBuilder = KotobaUIText.SkillWordProgress(true, wordKK, wordAlph, wordKKProgressIndex, wordAlphProgressIndex);

        enemyAttackWordUI.SetSkillWordTextUI(wordBuilder);
    }
}
