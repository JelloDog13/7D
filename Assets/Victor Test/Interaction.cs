using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FPSControllerLPFP;

public abstract class Interaction : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRb;
    [SerializeField] ItemChecker _itemChecker;
    [SerializeField] PlayerProgress _progressTracker;
    [SerializeField] Camera _mainCam;
    [SerializeField] float _cutSceneTime;
    [SerializeField] GameObject _player;
    public string _targetTag;
    public bool _isInteracting;

    public bool CanInteract()
    {
        if (_itemChecker.ItemCheck()) { _targetTag = _itemChecker.RaycastTag(); return true; }
        else { return false; }
    }

    public virtual void InteractWithObject()
    {           
        Debug.Log("Coroutine Start");
        StartCoroutine(CutSceneCoroutine());
    }

    IEnumerator CutSceneCoroutine()
    {     
        _isInteracting = true;
        yield return new WaitForSeconds(0.1f);
        _isInteracting = false;
        _playerRb.isKinematic = true;
        _player.GetComponent<FpsControllerLPFP>().enabled = false;
        yield return new WaitForSeconds(_cutSceneTime/2);
        if (!_itemChecker._targetObject._isAmmo)
        {
            _progressTracker.AddItem(_itemChecker._targetObject);
            Destroy(_itemChecker._targetObject.gameObject);
        }
        else // ADD AMMO
        yield return new WaitForSeconds(_cutSceneTime / 2);
        _playerRb.isKinematic = false;
        _player.GetComponent<FpsControllerLPFP>().enabled = true;

    }
}
