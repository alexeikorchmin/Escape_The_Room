using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Cat : Interactable
{
    [SerializeField] private float goalDistance = 2f;
    [SerializeField] private Transform [] catGoals;
    [SerializeField] private GameObject catCanvasHint;

    private int currentGoalIndex = 0;

    NavMeshAgent navMeshAgent;

    protected override void Awake()
    {
        base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = catGoals[0].position;
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance <= goalDistance)
        {
            StartCoroutine(WaitAnimationCoroutine());
            currentGoalIndex = ++currentGoalIndex;
            if (currentGoalIndex == catGoals.Length)
                currentGoalIndex = 0;
            navMeshAgent.destination = catGoals[currentGoalIndex].position;
        }
    }

    IEnumerator WaitAnimationCoroutine()
    {
        navMeshAgent.Stop();
        animator.Play("Jump");
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(audioTracks.GetAudioClipByType(AudioType.MeowHouseCat), 0.1f);
        animator.Play("sound");
        yield return new WaitForSeconds(1f);
        animator.Play("Walk");
        navMeshAgent.Resume();
    }

    IEnumerator WaitForCatHintCoroutine()
    {
        catCanvasHint.SetActive(true);
        yield return new WaitForSeconds(2f);
        catCanvasHint.SetActive(false);
    }

    public override void Interact()
    {
        audioSource.PlayOneShot(audioTracks.GetAudioClipByType(AudioType.MeowHouseCat), 0.1f);
        StartCoroutine(WaitForCatHintCoroutine());
    }
}