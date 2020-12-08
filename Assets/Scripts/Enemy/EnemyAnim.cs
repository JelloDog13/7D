using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] EnemyMovement _enemy;
    [SerializeField] EnemyFight _fight;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (_fight._isInRange)
        {
            Attack();
        }
        else 
        {
            Move();
        }

    }

    private void Move()
    {
        _anim.SetBool("Attack", false);
        _anim.SetFloat("Speed", _enemy._agent.velocity.magnitude);
    }

    private void Attack()
    {
        _anim.SetBool("Attack", true);
    }
}
