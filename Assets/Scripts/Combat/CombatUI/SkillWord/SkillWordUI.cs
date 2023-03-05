using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillWordUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI wordKKUI;

    [SerializeField]
    private TextMeshProUGUI wordAlphUI;

    public void SetSkillWordTextUI(StringBuilder[] wordBuilder)
    {
        wordKKUI.text = wordBuilder[0].ToString();
        wordAlphUI.text = wordBuilder[1].ToString();
    }
}
