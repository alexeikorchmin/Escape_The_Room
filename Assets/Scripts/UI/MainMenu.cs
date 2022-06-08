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
        StartCoroutine(WaitSceneLoadingCoroutine());
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

    private IEnumerator WaitSceneLoadingCoroutine()
    {
        OnButtonClicked?.Invoke();
        yield return new WaitForSeconds(1f);
        print("Good Bye");
        //Application.Quit();
    }
}