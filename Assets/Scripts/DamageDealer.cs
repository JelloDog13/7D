using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] AudioClip[] _hitFleshSFX, _hitPlayerSFX;
    [SerializeField] bool _isBullet;
    [SerializeField] int _playerDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (_isBullet)
        {
            if (collision.gameObject.CompareTag("Enemy") && !collision.gameObject.GetComponentInParent<EnemyMovement>()._isDead)
            {
                collision.gameObject.GetComponentInParent<EnemyFight>().TakeHit();
                AudioSource.PlayClipAtPoint(_hitFleshSFX[Random.Range(0, _hitFleshSFX.Length)], transform.position);
            }
            else if (collision.gameObject.CompareTag("Head") && !collision.gameObject.GetComponentInParent<EnemyMovement>()._isDead)
            {
                collision.gameObject.GetComponentInParent<EnemyFight>().Die();
                AudioSource.PlayClipAtPoint(_hitFleshSFX[Random.Range(0, _hitFleshSFX.Length)], transform.position);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(_playerDamage);
            AudioSource.PlayClipAtPoint(_hitPlayerSFX[Random.Range(0, _hitPlayerSFX.Length)], transform.position);
        }
    }
}
