using UnityEngine;
using UnityEngine.Video;

public class TVScreenVideoPlay : Interactable
{
    [SerializeField] private GameObject ScreenTV;

    private VideoPlayer videoPlayer;
    private bool isTVOn;

    public override void Interact()
    {
        if (isTVOn)
        {
            SwitchTVState(false);
            videoPlayer.Stop();
        }
        else
        {
            SwitchTVState(true);
            videoPlayer.Play();
        }
    }
   
    protected override void Awake()
    {
        videoPlayer = ScreenTV.GetComponent<VideoPlayer>();
    }

    private void SwitchTVState(bool flag)
    {
        ScreenTV.SetActive(flag);
        isTVOn = flag;
    }
}