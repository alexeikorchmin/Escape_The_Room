using UnityEngine;

class Clock : MonoBehaviour
{
    [SerializeField] private GameObject pointerSeconds;
    [SerializeField] private GameObject pointerMinutes;
    [SerializeField] private GameObject pointerHours;
    [SerializeField] private TimeManager timeManager;

    void Update()
    {
        ClockWallTime();
    }
    private void ClockWallTime()
    {
        //-- calculate pointer angles
        float rotationSeconds = (360.0f / 60.0f) * timeManager.GetSeconds();
        float rotationMinutes = (360.0f / 60.0f) * timeManager.GetMinutes();
        float rotationHours = ((360.0f / 12.0f) * timeManager.GetHours()) + ((360.0f / (60.0f * 12.0f)) * timeManager.GetMinutes());

        //-- draw pointers
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }
}
