using UnityEngine;
using TMPro;

class LaptopTimemanager : MonoBehaviour
{
    [SerializeField] TMP_Text textTime;
    [SerializeField] private TimeManager timeManager;
    void Update()
    {
        TimeToString();
    }
    private void TimeToString()
    {
        textTime.text = $"{timeManager.GetHours():d2}:{timeManager.GetMinutes():d2}:{timeManager.GetSeconds():d2}";
    }
}