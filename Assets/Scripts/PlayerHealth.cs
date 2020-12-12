using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;

    public int MaxHealth 
    { 
        get => _maxHealth;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
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
