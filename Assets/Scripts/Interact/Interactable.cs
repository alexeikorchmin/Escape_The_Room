using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Animator))]

public class Interactable : MonoBehaviour
{
    [SerializeField] protected AudioTracks audioTracks;

    protected Animator animator;
    protected AudioSource audioSource;
    protected BoxCollider boxCollider;

    public virtual void Interact() { }

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    protected virtual void PlaySound(AudioType audioType)
    {
        audioSource.PlayOneShot(audioTracks.GetAudioClipByType(audioType));
    }
}