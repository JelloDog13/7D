using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityManager : MonoBehaviour
{

    public int _sanityLevel;
    [SerializeField] GameObject _sanityGroup1, _sanityGroup2, _sanityGroup3;
    [SerializeField] Light _light;
    [SerializeField] WindZone _weather;
    //[SerializeField] TriggerScript _questProgress;


    void Start()
    {
        
    }


    void Update()
    {
        //if(new quest) => Switch level
    }

    private void SwitchSanityLevel()
    {
        if(_sanityLevel == 1)
        {
            _sanityGroup1.SetActive(true);         
        }
        else if (_sanityLevel == 2)
        {
            _sanityGroup2.SetActive(true);
            //Light modif
            //+ de vent
        }
        else if (_sanityLevel == 3)
        {
            _sanityGroup3.SetActive(true);
            //light modif
            //tempête
        }
    }
}
