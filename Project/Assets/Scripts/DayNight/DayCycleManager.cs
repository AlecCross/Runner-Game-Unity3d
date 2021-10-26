using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0,1)]
    public float TimeOfDay;
    public float DayDuration = 45f;
    public float sunIntensity;
    public Light Sun;
    public AnimationCurve SunCurve;
    void Start()
    {
        sunIntensity = Sun.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay >= 1) TimeOfDay -= 1;

        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 35, 35);
        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
    }
}
