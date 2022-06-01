using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Animator))]

public class Interactable : MonoBehaviour
{
    [SerializeField] protected AudioTracks audioTracks;

    protected Animator animator;
    protected AudioSource audioSource;
    protected BoxCollider boxCollider;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public virtual void Interact() { }

    protected virtual void PlaySound(AudioType audioType)
    {
        audioSource.PlayOneShot(audioTracks.GetAudioClipByType(audioType));
    }
}