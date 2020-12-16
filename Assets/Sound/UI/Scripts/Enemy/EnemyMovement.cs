using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FPSControllerLPFP;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public NavMeshAgent _agent;
    [SerializeField] LayerMask _playerMask;
    [SerializeField] Transform _playerPos;
    [SerializeField] Transform _probeCenter;
    [SerializeField] float _detectionRadius, _wanderRadius;
    [SerializeField] EnnemySpawner _spawner;
    public float _wanderSpeed, _attackSpeed, _waitTime;
    public bool _onWander, _onAlert, _isDead, _inWait;

    private void Awake()
    {
        _onWander = true;
        _playerPos = FindObjectOfType<FpsControllerLPFP>().transform;
        _spawner = FindObjectOfType<EnnemySpawner>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (!_isDead)
        {
            if (_spawner._isHanging)
            {
                Attack();
            }
            else if (RaycastPlayer())
            {
                Attack();
            }
            else { Wander(); }
        }
        else _agent.speed = 0;
    }

    public void IsDead()
    {
        _isDead = true;
    }

    private void Attack()
    {
        // SAFE ZONE MAISON
        Debug.Log("Attacking");
        _agent.SetDestination(_playerPos.position);

        Vector3 direction = (_playerPos.position - _probeCenter.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

        _agent.speed = _attackSpeed;

    }

    private void Wander()
    {
        _agent.speed = _wanderSpeed;
        if (!_inWait)
        {
            if (Vector3.Distance(_agent.destination, _agent.transform.position) <= _agent.stoppingDistance)
            {
                StartCoroutine(WaitAndSee());
            }
        }
    }
        
    private Vector3 RandomNavMesh(Vector3 origin, float distance, int layermask)
    {
        var randDirection = Random.insideUnitSphere * distance;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, distance, layermask);

        return navHit.position;
    }

    private IEnumerator WaitAndSee()
    {
        _inWait = true;
        yield return new WaitForSeconds(_waitTime);
        _inWait = false;
        Vector3 newPos = RandomNavMesh(transform.position, _wanderRadius, -1);
        _agent.SetDestination(newPos);
    }

    private bool RaycastPlayer()
    {
        var hitColliders = Physics.OverlapSphere(_probeCenter.position, _detectionRadius, _playerMask);
        for (var i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Player")
            {
                Debug.Log("Found Player !");
                return true;
            }
            else return false;

        }
        return false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(_probeCenter.position, _detectionRadius);
    }

}
