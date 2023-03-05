using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatHPBarUI : MonoBehaviour
{
    [SerializeField]
    private Image characterHPBarFill;

    [SerializeField]
    private float changeFillDuration = 1.0f;

    public void ChangeHPBarFill(float hpPercent, bool instantChangeFill = false)
    {
        if (!instantChangeFill)
        {
            StartCoroutine(ChangeFillCoroutine(hpPercent));
        }
        else
        {
            ChangeFill(hpPercent);
        }        
    }

    private IEnumerator ChangeFillCoroutine(float hpPercent)
    {
        float time = 0;

        float initialFill = characterHPBarFill.fillAmount;

        float finalFill = hpPercent;

        while (time < changeFillDuration)
        {
            characterHPBarFill.fillAmount = Mathf.Lerp(initialFill, finalFill, time / changeFillDuration);

            time += Time.deltaTime;

            yield return null;
        }

        characterHPBarFill.fillAmount = finalFill;
    }

    private void ChangeFill(float hpPercent)
    {
        characterHPBarFill.fillAmount = hpPercent;
    }
}
