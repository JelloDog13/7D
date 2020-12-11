using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FPSControllerLPFP;

public abstract class Interaction : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRb;
    [SerializeField] ItemChecker _itemChecker;
    [SerializeField] Camera _mainCam;
    [SerializeField] float _cutSceneTime;
    [SerializeField] GameObject _player;

    //    public virtual void InteractWithObject(string tag)
    //    {
    //        if (_itemChecker.ItemCheck() && _itemChecker._hitBuffer[0].collider.CompareTag(tag))
    //        {
    //            _pickUpItemText.text = "Press V to pick up" + " " + "the" + " " + tag;

    //            if (Input.GetKeyDown(KeyCode.V))
    //            {
    //                _playerRb.constraints = RigidbodyConstraints.FreezeAll;

    //                if (_itemChecker._hitBuffer[0].collider.CompareTag("Flower"))
    //                {
    //                    _itemChecker._hitBuffer[0].collider.gameObject.SetActive(false);
    //                }

    //                if (_itemChecker._hitBuffer[0].collider.CompareTag("DogToy"))
    //                {
    //                    _itemChecker._hitBuffer[0].collider.gameObject.SetActive(false);
    //                }

    //                if (_itemChecker._hitBuffer[0].collider.CompareTag("Logs"))
    //                {
    //                    _itemChecker._hitBuffer[0].collider.gameObject.SetActive(false);
    //                }
    //            }
    //        }
    //    }

    public virtual void InteractWithObject(string tag)
    {
        if (_itemChecker.ItemCheck() /*&& _itemChecker._hitBuffer[0].collider.CompareTag(tag)*/)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Debug.Log("Coroutine Start");
                StartCoroutine(CutSceneCoroutine());
            }
        }
    }

    IEnumerator CutSceneCoroutine()
    {
        _playerRb.isKinematic = true;
        _player.GetComponent<FpsControllerLPFP>().enabled = false;
        //_mainCam.transform.LookAt(_itemChecker._hitBuffer[0].transform);
        //FONDU AU NOIR
        yield return new WaitForSeconds(_cutSceneTime);
        _playerRb.isKinematic = false;
        _player.GetComponent<FpsControllerLPFP>().enabled = true;
    }
}
