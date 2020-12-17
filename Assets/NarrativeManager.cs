using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using FPSControllerLPFP;

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
    [SerializeField] GameObject _weapon;
    [SerializeField] GameObject _arms;
    [SerializeField] Transform _backHomePositionTransform;
    [SerializeField] Transform _playerTransform;
    [SerializeField] HandgunScriptLPFP _handgunScript;
    [SerializeField] GameObject[] _questItemArray = new GameObject[3];

    private bool _hasReturned;
    private bool _introIsFinished;
    private bool _gameStarted;
    

    private void Awake()
    {
        _texte1.gameObject.SetActive(true);
        _introIsFinished = false;
        _gameStarted = true;
    }

    private void Start()
    {
        _weapon.SetActive(false);
        _arms.SetActive(false);
        _handgunScript.enabled = false;
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
        _playerTransform.position = _backHomePositionTransform.position;
        _playerTransform.rotation = _backHomePositionTransform.rotation;
        _handgunScript.enabled = true;
        _weapon.SetActive(true);
        _arms.SetActive(true);
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
