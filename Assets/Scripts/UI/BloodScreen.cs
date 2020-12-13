using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BloodScreen : MonoBehaviour
{
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] int _dangerZone = 10;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _alpha = new Color(255f, 255f, 255f, 0f);
        _image.color= _alpha;
    }

    private void Update()
    {
        if(_playerHealth.IsHit)
        {
            Debug.Log("TOUCHER!!!!!");
            //_image.DOColor(endValue: new Color(255f, 255f, 255f, 255f), duration: 2).SetEase(Ease.Flash);
            _image.DOFade(255f, 1.5f);
        }

        if(_playerHealth.MaxHealth <= _dangerZone)
        {
            Debug.Log("TU VAS CREVER!!!!!");
            _image.DOColor(endValue: new Color(255f, 255f, 255f, 255f), duration: 2).SetEase(Ease.Flash);
        }
    }

    private Image _image;
    private Color _color;
    private Color _alpha;
}
