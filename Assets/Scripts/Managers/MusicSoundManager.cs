using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MusicSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceSound;
    [SerializeField] private AudioSource audioSourceMusic;

    private void Awake()
    {
        MainMenu.OnButtonClicked += PlayClickSound;
    }

    private void PlayClickSound()
    {
        audioSourceSound.PlayOneShot(audioSourceSound.clip);
    }

    private void OnDestroy()
    {
        MainMenu.OnButtonClicked -= PlayClickSound;
    }
}