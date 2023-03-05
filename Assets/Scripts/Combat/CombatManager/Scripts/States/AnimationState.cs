using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using SimpleStateMachine;

public class AnimationState : State
{
    [SerializeField]
    private TypingState typingState;

    [SerializeField]
    private CurrentSkillManager currentSkillManager;

    [SerializeField]
    private PlayableDirector skillDirector;

    private Character currentSkillUser;

    //Test purposes
    [SerializeField]
    private Image animationTestUI;

    private bool isTestAnimation = false;

    private float defaultDuration = 1.5f;

    private Coroutine animationCoroutineTemp = null;

    public override void EnterState()
    {
        SkillWordTemplate currentSkill = currentSkillManager.UsedSkill;

        currentSkillUser = currentSkillManager.User;

        int cutsceneIndex = 0;

        if (currentSkillUser.TryGetComponent(out Player player))
        {
            cutsceneIndex = 0;
        }
        else
        {
            cutsceneIndex = 1;
        }

        if (currentSkill.SkillCutscenes[cutsceneIndex] != null)
        {
            isTestAnimation = false;
            skillDirector.Play(currentSkill.SkillCutscenes[cutsceneIndex]);
        }
        else
        {
            isTestAnimation = true;
            animationCoroutineTemp = StartCoroutine(AnimationCoroutineTemp());
        }

        base.EnterState();
    }

    public override State UpdateState()
    {
        if (!isTestAnimation && skillDirector.state != PlayState.Playing)
        {
            return typingState;
        }

        if (isTestAnimation && animationCoroutineTemp == null)
        {
            return typingState;
        }

        return base.UpdateState();
    }

    private IEnumerator AnimationCoroutineTemp()
    {
        float time = 0f;

        animationTestUI.fillAmount = 0f;

        while (time < defaultDuration)
        {
            time += Time.deltaTime;

            animationTestUI.fillAmount = Mathf.Lerp(0f, 1f, time / defaultDuration);

            yield return null;
        }

        animationTestUI.fillAmount = 1f;

        yield return null;

        animationTestUI.fillAmount = 0f;

        animationCoroutineTemp = null;
    }
}
