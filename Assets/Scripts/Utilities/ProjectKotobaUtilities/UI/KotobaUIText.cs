using System.Text;

namespace ProjectKotoba
{
    namespace UI
    {
        namespace Text
        {
            public static class KotobaUIText
            {
                public static StringBuilder[] SkillWordProgress(bool isSelectedWord, string[] wordKK, string[] wordAlph, int wordKKProgressIndex, int wordAlphProgressIndex)
                {
                    //書いていない文字と選択されてない言葉の透明の値（RichTextが必要）
                    string notTypedLetterAlphaTag = "<alpha=#66>"; //40%の透明

                    //漢字仮名版の言葉は i = 0 | アルファベット版の言葉は i = 1
                    StringBuilder[] wordBuilder = { new StringBuilder(), new StringBuilder() };

                    //もし言葉は選択されていたら打っている文字までに何もしない、その文字の後だけに透明を適用する
                    if (isSelectedWord)
                    {
                        for (int wordKKIndex = 0; wordKKIndex < wordKK.Length; wordKKIndex++)
                        {
                            if (wordKKIndex == wordKKProgressIndex)
                            {
                                wordBuilder[0].Append(notTypedLetterAlphaTag); //透明を適用する（漢字仮名）

                                for (int wordAlphIndex = 0; wordAlphIndex < wordAlph[wordKKIndex].Length; wordAlphIndex++)
                                {
                                    if (wordAlphIndex == wordAlphProgressIndex)
                                    {
                                        wordBuilder[1].Append(notTypedLetterAlphaTag); //透明を適用する（アルファベット）
                                    }

                                    wordBuilder[1].Append(wordAlph[wordKKIndex][wordAlphIndex]);
                                }
                            }
                            else
                            {
                                wordBuilder[1].Append(wordAlph[wordKKIndex]); //今回の文字を追加する（アルファベット）
                            }

                            wordBuilder[0].Append(wordKK[wordKKIndex]); //今回の文字を追加する（漢字仮名）
                        }
                    }
                    else //言葉は選択されてない場合は言葉全体に透明を適用する
                    {
                        wordBuilder[0].Append(notTypedLetterAlphaTag + string.Concat(wordKK));
                        wordBuilder[1].Append(notTypedLetterAlphaTag + string.Concat(wordAlph));
                    }

                    return wordBuilder;
                }
            }
        }
    }
}
