using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectKotoba
{
    namespace Gameplay
    {
        namespace Typing
        {
            public static class KotobaGameplayTyping
            {
                ///<summary>プレイヤーが使うAddWordProgress</summary>
                public static void AddWordProgress(char inputChar, string[] currentSkillWordAlph, ref int wordCurrentKKIndex, ref int wordKKCurrentAlphIndex, ref bool finishWord)
                {
                    string currentKKIndexAlphText = currentSkillWordAlph[wordCurrentKKIndex];

                    if (inputChar == currentKKIndexAlphText[wordKKCurrentAlphIndex])
                    {
                        wordKKCurrentAlphIndex++;

                        if (wordKKCurrentAlphIndex == currentKKIndexAlphText.Length)
                        {
                            wordKKCurrentAlphIndex = 0;
                            wordCurrentKKIndex++;

                            if (wordCurrentKKIndex == currentSkillWordAlph.Length)
                            {
                                finishWord = true;
                            }
                        }
                    }
                }

                ///<summary>敵が使うAddWordProgress</summary>
                public static void AddWordProgress(string[] currentSkillWordAlph, ref int wordCurrentKKIndex, ref int wordKKCurrentAlphIndex, ref bool finishWord)
                {
                    string currentKKIndexAlphText = currentSkillWordAlph[wordCurrentKKIndex];

                    wordKKCurrentAlphIndex++;

                    if (wordKKCurrentAlphIndex == currentKKIndexAlphText.Length)
                    {
                        wordKKCurrentAlphIndex = 0;
                        wordCurrentKKIndex++;

                        if (wordCurrentKKIndex == currentSkillWordAlph.Length)
                        {
                            finishWord = true;
                        }
                    }
                }
            }
        }
    }
}



