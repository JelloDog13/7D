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
    }


    void Update()
    {
        
    }
}
