using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceMusic : MonoBehaviour
{
    [Header("Ambiance Clips")]
    [SerializeField] AudioClip _ambiance1;
    [SerializeField] AudioClip _ambiance2;
    [SerializeField] AudioClip _ambiance3;
    [Header("Music Clips")]
    [SerializeField] AudioClip _music1;
    [SerializeField] AudioClip _music2;
    [SerializeField] AudioClip _music3;

    [Header("Components")]
    [SerializeField] AudioSource _audioAmbi, _audioMusic;

    void Start()
    {
        _audioAmbi.clip = _ambiance1;
        _audioAmbi.Play();
    }

    public void SwitchTo1()
    {
        _audioAmbi.clip = _ambiance1;
        _audioAmbi.Play();
    }

    public void SwitchTo2()
    {
        _audioAmbi.clip = _ambiance2;
        _audioAmbi.Play();
    }

    public void SwitchTo3()
    {
        _audioAmbi.clip = _ambiance3;
        _audioAmbi.Play();
    }

}

