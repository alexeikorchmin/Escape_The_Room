using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField ] private float timeOfDay;
    [SerializeField] private float dayDuration;

    [SerializeField] private Light sun;
    [SerializeField] private Light moon;

    [SerializeField] private AnimationCurve sunCurve;
    [SerializeField] private AnimationCurve moonCurve;
    [SerializeField] private AnimationCurve skyBoxCurve;

    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;

    [SerializeField] private ParticleSystem stars;

    private float sunIntensity;
    private float moonIntensity;
    
    private void Start()
    {
        sunIntensity = sun.intensity;
        moonIntensity = moon.intensity;
    }

    private void Update()
    {
        SunMoonPositionChange();
    }

    private void SunMoonPositionChange()
    {
        var StarsMainModule = stars.main;
        StarsMainModule.startColor = new Color(1, 1, 1, 1 - skyBoxCurve.Evaluate(timeOfDay));

        timeOfDay += Time.deltaTime / dayDuration;

        if (timeOfDay >= 1)
            timeOfDay -= 1;

        sun.transform.localRotation = Quaternion.Euler(timeOfDay * 360f, 180, 0);
        moon.transform.localRotation = Quaternion.Euler(timeOfDay * 360f + 180, 180, 0);

        sun.intensity = sunCurve.Evaluate(timeOfDay);
        moon.intensity = moonCurve.Evaluate(timeOfDay);

        RenderSettings.skybox.Lerp(nightSkybox, daySkybox, skyBoxCurve.Evaluate(timeOfDay));
        RenderSettings.sun = skyBoxCurve.Evaluate(timeOfDay) > 0.1 ? sun : moon;
    }
}