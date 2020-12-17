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
        StartCoroutine(HitDuration());
        _maxHealth -= damage;
        if(_maxHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        StartCoroutine(DeathFade());
    }

    IEnumerator HitDuration()
    {
        _isHit = true;
        yield return new WaitForEndOfFrame();
        _isHit = false;
    }

    IEnumerator DeathFade()
    {
        FindObjectOfType<QuestItemInteraction>().Fade();
        yield return new WaitForSeconds(3);
        FindObjectOfType<SceneLoader>().ReloadScene();
    }

    private bool _isHit;

    public bool IsHit
    {
        get => _isHit;
    }
}
