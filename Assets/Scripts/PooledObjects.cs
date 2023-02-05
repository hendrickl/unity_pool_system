using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{
    // Variables for debug
    private int _totalSpawnedObj = 0;
    private int _totalPooledObj = 0;

    [SerializeField] private GameObject _objectToPool;
    private List<GameObject> _pool = new List<GameObject>();

    private GameObject SpawnObjectFromPool(GameObject prefab, List<GameObject> pool, Vector3 location)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].transform.position = location;
                pool[i].gameObject.SetActive(true);
                _totalPooledObj++;
                return pool[i];
            }
        }

        GameObject objectToSpawn = Instantiate(prefab, location, Quaternion.identity);
        pool.Add(objectToSpawn);
        _totalSpawnedObj++;
        return objectToSpawn;
    }

    public GameObject GetObjectFromPool(Vector3 location)
    {
        return SpawnObjectFromPool(_objectToPool, _pool, location);
    }
}
