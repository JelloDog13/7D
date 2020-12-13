using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLevel : MonoBehaviour
{
    [SerializeField] WindZone _wind;

    void Update()
    {
        
    }

    public void SetLevel2()
    {
        _wind.windPulseFrequency = 0.5f;
        _wind.windPulseMagnitude = 0.8f;
        _wind.windMain = 0.3f;
        _wind.windTurbulence = 0.3f;
    }
    public void SetLevel3()
    {
        _wind.windPulseFrequency = 1.2f;
        _wind.windPulseMagnitude = 1.2f;
        _wind.windMain = 0.7f;
        _wind.windTurbulence = 2.6f;
    }
}
