using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceMusic : MonoBehaviour
{
    [SerializeField] AudioClip _ambiance1, _ambiance2, _ambiance3;
<<<<<<< HEAD
    [SerializeField] AudioSource _audioAmbi, _audioMusic;

    void Start()
    {
        _audioAmbi.clip = _ambiance1;
=======
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = _ambiance1;
>>>>>>> Player
    }

    public void SwitchTo1()
    {
<<<<<<< HEAD
        _audioAmbi.clip = _ambiance1;
    }
    public void SwitchTo2()
    {
        _audioAmbi.clip = _ambiance2;
    }
    public void SwitchTo3()
    {
        _audioAmbi.clip = _ambiance3;
=======
        _audio.clip = _ambiance1;
    }
    public void SwitchTo2()
    {
        _audio.clip = _ambiance2;
    }
    public void SwitchTo3()
    {
        _audio.clip = _ambiance3;
>>>>>>> Player
    }
}

