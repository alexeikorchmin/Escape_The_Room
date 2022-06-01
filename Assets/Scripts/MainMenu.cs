using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip audioclip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        StartCoroutine(WaitSceneLoadingCoroutine(audioclip, "Game"));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        StartCoroutine(WaitSceneLoadingCoroutine(audioclip, "MainMenu"));
    }

    IEnumerator WaitSceneLoadingCoroutine(AudioClip audioClip, string sceneName)
    {
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}