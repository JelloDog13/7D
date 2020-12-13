using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] TMP_Text _texte1;
    [SerializeField] AudioSource _scream;
    [SerializeField] Animator _fade;

    private bool _introIsFinished;

    private void Awake()
    {
        _texte1.gameObject.SetActive(true);
        _introIsFinished = false;
    }

    private void Update()
    {
        if (!_introIsFinished)
        {
            StartCoroutine(EndOfIntroCoroutine());
        }
    }

    IEnumerator EndOfIntroCoroutine()
    {
        yield return new WaitForSeconds(60);
        _fade.Play("Fade");
        _scream.Play();
        yield return new WaitForSeconds(2);
    }
}
