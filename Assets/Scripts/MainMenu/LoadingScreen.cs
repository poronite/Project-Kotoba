using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FadeType
{
    In,
    Out
}


public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup loadingScreenCanvasGroup;

    [SerializeField]
    private float fadeInDuration;

    [SerializeField]
    private float fadeOutDuration;

    private static LoadingScreen loadingScreenInstance;

    public static LoadingScreen LoadingScreenInstance
    {
        get
        {
            return loadingScreenInstance;
        }
    }


    private void Awake()
    {
        SetLoadingScreenInstance();
    }

    private void SetLoadingScreenInstance()
    {
        if (loadingScreenInstance == null)
        {            
            loadingScreenInstance = this;
            loadingScreenInstance.name = "LoadingScreen";
            DontDestroyOnLoad(loadingScreenInstance);
        }
    }


    public IEnumerator FadeLoadingScreen(FadeType type)
    {
        float time = 0f;

        float startValue = 0f;

        float targetValue = 0f;

        float duration = 0f;

        switch (type)
        {
            case FadeType.In:
                startValue = 0f;
                targetValue = 1f;
                duration = fadeInDuration;
                break;
            case FadeType.Out:
                startValue = 1f;
                targetValue = 0f;
                duration = fadeOutDuration;
                break;
            default:
                break;
        }

        while (time < duration)
        {
            loadingScreenCanvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        //this is here to guarantee that the alpha is 1 (or 0) instead of a very close float value
        loadingScreenCanvasGroup.alpha = targetValue;
    }
}
