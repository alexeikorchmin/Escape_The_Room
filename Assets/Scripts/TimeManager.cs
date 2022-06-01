using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int minutes = 0;
    private int hours = 0;
    private int seconds = 0;
    private float msecs = 0;

    [SerializeField] private float clockSpeed = 1f;
    [SerializeField] private bool realTime;

    void Update()
    {
        GameTimeApply();
    }

    private void GameTimeApply()
    {
        switch (realTime)
        {
            case true:
                hours = System.DateTime.Now.Hour;
                minutes = System.DateTime.Now.Minute;
                seconds = System.DateTime.Now.Second;
                break;

                case false:
                msecs += Time.deltaTime * clockSpeed;

                if (msecs >= 1.0f)
                {
                    msecs -= 1.0f;
                    seconds++;
                    if (seconds >= 60)
                    {
                        seconds = 0;
                        minutes++;
                        if (minutes > 60)
                        {
                            minutes = 0;
                            hours++;
                            if (hours >= 24)
                                hours = 0;
                        }
                    }
                }
                break;
        }
    }

    public int GetMinutes() => minutes;
    public int GetHours() => hours;
    public int GetSeconds() => seconds;
}