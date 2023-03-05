using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    public IEnumerator StartGameCoroutine()
    {
        yield return StartCoroutine(LoadingScreen.LoadingScreenInstance.FadeLoadingScreen(FadeType.In));

        yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

        yield return StartCoroutine(LoadingScreen.LoadingScreenInstance.FadeLoadingScreen(FadeType.Out));
    }
}
