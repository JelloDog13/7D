using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] AudioClip[] _hitFleshSFX, _hitPlayerSFX;
    [SerializeField] bool _isBullet;
    [SerializeField] int _playerDamage;
    [SerializeField] GameObject _hitFleshVFX, _hitVFX;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isBullet)
        {
            if (collision.gameObject.CompareTag("Enemy") && !collision.gameObject.GetComponentInParent<EnemyMovement>()._isDead)
            {
                collision.gameObject.GetComponentInParent<EnemyFight>().TakeHit();
                AudioSource.PlayClipAtPoint(_hitFleshSFX[Random.Range(0, _hitFleshSFX.Length)], transform.position);
                GameObject bulletImpact = GameObject.Instantiate(_hitFleshVFX, transform.position, Quaternion.identity) as GameObject;
                Destroy(bulletImpact, 0.5f);
            }
            else if (collision.gameObject.CompareTag("Head") && !collision.gameObject.GetComponentInParent<EnemyMovement>()._isDead)
            {
                collision.gameObject.GetComponentInParent<EnemyFight>().Die();
                AudioSource.PlayClipAtPoint(_hitFleshSFX[Random.Range(0, _hitFleshSFX.Length)], transform.position);
                GameObject bulletImpact = GameObject.Instantiate(_hitFleshVFX, transform.position, Quaternion.identity) as GameObject;
                Destroy(bulletImpact, 0.5f);
            }
            else
            {
            GameObject bulletImpact = GameObject.Instantiate(_hitVFX, transform.position, Quaternion.identity) as GameObject;
            Destroy(bulletImpact, 0.5f);
            }
    }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(_playerDamage);
            AudioSource.PlayClipAtPoint(_hitPlayerSFX[Random.Range(0, _hitPlayerSFX.Length)], transform.position);
        }
    }
}
