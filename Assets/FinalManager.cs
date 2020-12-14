using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FPSControllerLPFP;
using TMPro;

public class FinalManager : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Transform _hangTransform;
    [SerializeField] Rigidbody _playerRb;
    [SerializeField] TMP_Text _hangText;
    [SerializeField] TMP_Text _lastText;
    [SerializeField] FpsControllerLPFP _fpsControllerLPFP;

    private bool _canHang;

    private void Start()
    {
        _playerTransform.position = _hangTransform.position;
        _playerTransform.rotation = _hangTransform.rotation;
        _playerRb.isKinematic = true;
        StartCoroutine(FinalCoroutine());
        _fpsControllerLPFP.enabled = false;
    }

    private void Update()
    {
        if (_canHang)
        {
            if(Input.GetKeyDown(KeyCode.V))
            {

            }
        }
    }

    IEnumerator FinalCoroutine()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(5);
        _fpsControllerLPFP.enabled = true;
        _lastText.gameObject.SetActive(false);
        _hangText.gameObject.SetActive(true);
        _canHang = true;

    }
}
