using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationUI : MonoBehaviour
{
    //on lance l'animation du slide titre
    //si _doFade est vrais
    //alors on lance l'animtion fadeOut

    private bool _doFade;

    public bool DoFade { get => _doFade; set => _doFade = value; }
}
