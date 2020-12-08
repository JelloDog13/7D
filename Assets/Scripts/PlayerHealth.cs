using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    [SerializeField] float _shakeTime;
    [SerializeField] CameraShake _cam;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        //_cam.ShakeCamera();
        _maxHealth -= damage;
        if(_maxHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {

    }


}
