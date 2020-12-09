using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceMusic : MonoBehaviour
{
    [SerializeField] AudioClip _ambiance1, _ambiance2, _ambiance3;
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = _ambiance1;
    }

    public void SwitchTo1()
    {
        _audio.clip = _ambiance1;
    }
    public void SwitchTo2()
    {
        _audio.clip = _ambiance2;
    }
    public void SwitchTo3()
    {
        _audio.clip = _ambiance3;
    }
}

