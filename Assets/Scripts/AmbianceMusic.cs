using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceMusic : MonoBehaviour
{
    [SerializeField] AudioClip _ambiance1, _ambiance2, _ambiance3;
    [SerializeField] AudioSource _audioAmbi, _audioMusic;


    void Start()
    {
        _audioAmbi.clip = _ambiance1;
    }

    public void SwitchTo1()
    {
        _audioAmbi.clip = _ambiance1;
    }
    public void SwitchTo2()
    {
        _audioAmbi.clip = _ambiance2;
    }
    public void SwitchTo3()
    {
        _audioAmbi.clip = _ambiance3;
    }

}

