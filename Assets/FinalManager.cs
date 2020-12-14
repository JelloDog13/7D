using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPSControllerLPFP;
using TMPro;
using Cinemachine;

public class FinalManager : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _hangTransform;
    [SerializeField] Rigidbody _playerRb;
    [SerializeField] TMP_Text _hangText;
    [SerializeField] TMP_Text _lastText;
    [SerializeField] FpsControllerLPFP _fpsControllerLPFP;
    [SerializeField] CinemachineVirtualCamera _CM1;//La cam de base du player
    [SerializeField] CinemachineVirtualCamera _CM2;//La cam derrière la potence qui permet le lent travelling
    [SerializeField] CinemachineVirtualCamera _CM3;//La cam qui rentre dans le noeud coulant
    [SerializeField] GameObject _potence;

    private bool _canHang;

    private void Start()
    {
        _CM2.gameObject.SetActive(true);
        _playerRb.isKinematic = true;
        StartCoroutine(FinalCoroutine());
        _fpsControllerLPFP.enabled = false;
    }

    private void Update()
    {
        if (_canHang) //Check qu'on soit arrivé à la fin de la coroutine "FinalCoroutine" pour permettre au joueur de faire un input
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                _CM1.gameObject.SetActive(false);//Ici commence la danse des caméras
                _CM3.gameObject.SetActive(true);//Avec Cinemachine et un custom blend qui permet de faire des travelling en activant/desactivant les cams
                _hangText.gameObject.SetActive(false);
                StartCoroutine(HangYourselfCoroutine());
            }
        }
    }

    IEnumerator FinalCoroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(0.5f);
        _CM1.gameObject.SetActive(true);
        _CM2.gameObject.SetActive(false);
        yield return new WaitForSeconds(12);
        _fpsControllerLPFP.enabled = true;
        _lastText.gameObject.SetActive(false);
        _hangText.gameObject.SetActive(true);
        _canHang = true;
    }

    IEnumerator HangYourselfCoroutine()//Cette Coroutine sert à attendre la fin du switch entre la vcam3 et la vcam1
    {
        yield return new WaitForSeconds(3);

        _playerTransform.position = _hangTransform.position;
        _playerTransform.rotation = _hangTransform.rotation;
        _CM3.gameObject.SetActive(false);
        _CM1.gameObject.SetActive(true);
        _CM1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 5;
        _potence.SetActive(false);
    }
}
