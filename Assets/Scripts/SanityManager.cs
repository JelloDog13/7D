using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SanityManager : MonoBehaviour
{

    public int _sanityLevel;
    [SerializeField] GameObject _sanityGroup1, _sanityGroup2, _sanityGroup3;
    [SerializeField] GameObject _cabane1, _cabane2;
    [SerializeField] Light _light;
    [SerializeField] WindLevel _weather;
    [SerializeField] AmbianceMusic _ambiance;
    [SerializeField] LightingSettings _light1, _light2, _light3;

    void Start()
    {
        _light.intensity = 3;
        _sanityLevel = 1;
    }

    public void IncreaseSanity()
    {
        _sanityLevel++;
        SwitchSanityLevel();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            IncreaseSanity();
        }
        //if(new quest) => Switch level
    }

    private void SwitchSanityLevel()
    {
        if(_sanityLevel == 1)
        {
            //_sanityGroup1.SetActive(true);
            _ambiance.SwitchTo1();
            Lightmapping.lightingSettings = _light1;
        }
        else if (_sanityLevel == 2)
        {
            //_sanityGroup2.SetActive(true);
            _ambiance.SwitchTo2();
            _weather.SetLevel2();
            _light.intensity = 1;
            Lightmapping.lightingSettings = _light2;

            //+ de vent
        }
        else if (_sanityLevel == 3)
        {
            _cabane1.SetActive(false);
            _cabane2.SetActive(true);
            //_sanityGroup3.SetActive(true);
            _ambiance.SwitchTo3();
            _weather.SetLevel3();
            Lightmapping.lightingSettings = _light3;
            //light modif
            //tempête
        }
    }
}
