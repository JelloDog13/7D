using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BloodScreen : MonoBehaviour
{
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] int _dangerZone = 10;
    private bool _isBleeding;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _alpha = new Color(255f, 255f, 255f, 0f);
        _image.color = _alpha;
    }
    
    private void Update()
    {
        if(_playerHealth.IsHit)
        {
            Debug.Log("TOUCHER!!!!!");
            ApplySequenceHit();
        }

        if(_playerHealth.MaxHealth <= _dangerZone && !_isBleeding)
        {
<<<<<<< HEAD:Assets/Sound/UI/Scripts/UI/BloodScreen.cs
            _isBleeding = true;
            Debug.Log("TU VAS CREVER!!!!!");
            StartCoroutine(DelayDangerZoneAnimation());
=======
            //Debug.Log("TU VAS CREVER!!!!!");
            if (_playerHealth.IsHit)
            {
                _isCloseToDeath = true;
            }
                
            if (_isCloseToDeath) 
            {
                ApplySequenceDangerZone();
                StartCoroutine(DelayDangerZoneAnimation());
            }
>>>>>>> UI:Assets/Scripts/UI/BloodScreen.cs
        }
    }

    private void ApplySequenceHit()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_image.DOFade(endValue: 0.5f, duration: 0.5f));
        sequence.PrependInterval(0.2f);
        sequence.Append(_image.DOFade(endValue: 0f, duration: 0.5f));
    }

    private void ApplySequenceDangerZone()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_image.DOFade(endValue: 0.9f, duration: 0.5f));
        //sequence.PrependInterval(0.2f);
        sequence.Append(_image.DOFade(endValue: 0.2f, duration: 0.5f));
        sequence.SetLoops(-1, LoopType.Yoyo).SetSpeedBased();
    }

    IEnumerator DelayDangerZoneAnimation()
    {
        Debug.Log("TU VAS CREVER!!!!!");
        yield return new WaitForEndOfFrame();
        _isCloseToDeath = false;
    }

    public bool _isCloseToDeath;
    private Image _image;
    private Color _alpha;
}
