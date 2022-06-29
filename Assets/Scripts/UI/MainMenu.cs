using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public static Action OnButtonClicked;

    public void PlayGame()
    {
        StartCoroutine(WaitSceneLoadingCoroutine("Game"));
    }

    public void ExitGame()
    {
        StartCoroutine(WaitBeforeExitCoroutine());
    }

    public void BackToMainMenu()
    {
        StartCoroutine(WaitSceneLoadingCoroutine("MainMenu"));
    }

    private IEnumerator WaitSceneLoadingCoroutine(string sceneName)
    {
        OnButtonClicked?.Invoke();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator WaitBeforeExitCoroutine()
    {
        OnButtonClicked?.Invoke();
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}