using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _ennemyPrefab;
    [SerializeField] Transform [] _ennemySpawnerTransform;
    [SerializeField] SanityManager _sanityManager;
    public bool _isHanging;


    public void SpawnEnnemies(int numberOfEnnemies)
    {
        foreach (Transform spawnPoint in _ennemySpawnerTransform)
        {
            for (int i = 0; i < numberOfEnnemies; i++)
            {
                var obj = Instantiate(_ennemyPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
                obj.transform.parent = GameObject.Find("BADDIES").transform;
            }
        }
    }
}
