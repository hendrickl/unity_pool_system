using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{
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
                return pool[i];
            }
        }

        GameObject objectToSpawn = Instantiate(prefab, location, Quaternion.identity);
        pool.Add(objectToSpawn);
        return objectToSpawn;
    }
}
