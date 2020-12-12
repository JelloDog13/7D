using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class BloodScreen : MonoBehaviour
{
    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Update()
    {
        
    }

    private Image _image;
}
