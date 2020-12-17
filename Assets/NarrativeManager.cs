using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] TMP_Text _texte1;
    [SerializeField] TMP_Text _texte2;
    [SerializeField] GameObject _questPanel;
    [SerializeField] AudioClip _angryCrowdSound;
    [SerializeField] Animator _fade;
    [SerializeField] AudioSource _narrativeAudioSource;
    [SerializeField] Image _blackScreen;
    [SerializeField] GameObject[] _questObjects;

    private bool _hasReturned;
    private bool _introIsFinished;
    private bool _gameStarted;
    

    private void Awake()
    {
        _texte1.gameObject.SetActive(true);
        _introIsFinished = false;
        _gameStarted = true;
    }

    private void Update()
    {
        if (!_introIsFinished && _gameStarted)
        {
            _gameStarted = false;
            StartCoroutine(EndOfIntroCoroutine());
        }
    }

    IEnumerator EndOfIntroCoroutine()
    {
        yield return new WaitForSeconds(4);
        _texte1.gameObject.SetActive(false);
        yield return new WaitForSeconds(10);
        _fade.gameObject.SetActive(true);
        _fade.Play("FadeIn");
        _narrativeAudioSource.PlayOneShot(_angryCrowdSound);
        yield return new WaitForSeconds(4);
        _questPanel.SetActive(true);
        _fade.Play("FadeOut");
        _texte2.gameObject.SetActive(false);
        _introIsFinished = true;        
        yield return new WaitForSeconds(5);
        _blackScreen.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_hasReturned && _introIsFinished)
        {
            _hasReturned = true;
            foreach(GameObject obj in _questObjects)
            {
                obj.SetActive(true);
            }
            Destroy(GetComponent<Collider>());
        }
    }
}
