using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] EnemyMovement _enemy;
    [SerializeField] LayerMask _playerMask;
    [SerializeField] int _bulletsToKill;
    [SerializeField] float _meleeRadius;
    [SerializeField] EnemyAnim _anim;
    [SerializeField] GameObject _weapon;
    [SerializeField] AudioClip[] _gruntSFX, _deathSFX;

    public bool _isInRange, _isHit;

    void Start()
    {
        
    }

    void Update()
    {
        _isInRange = CheckForPlayer();
    }

    private bool CheckForPlayer()
    {
        var hitColliders = Physics.OverlapSphere(transform.position, _meleeRadius, _playerMask);
        for (var i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Player")
            {
                Debug.Log("In Range");
                _isInRange = true;
                return true;
            }
            else _isInRange = false;
            return false;
        }
        return false;
    }

    public void TakeHit()
    {
        _bulletsToKill--;
        _anim.TakeHit();
        if(_bulletsToKill <= 0)
        {
            if (Random.Range(0, 2) == 1)
            {
                AudioSource.PlayClipAtPoint(_gruntSFX[Random.Range(0, _gruntSFX.Length)], transform.position);
            }
            Die();
        }      
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(_deathSFX[Random.Range(0, _deathSFX.Length)], transform.position);
        GetComponentInChildren<RagdollController>().SetRagdoll();
        var damage = _weapon.GetComponent<DamageDealer>();
        Destroy(damage);
        _weapon.transform.parent = null;
        _enemy.IsDead();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _meleeRadius);
    }
}
