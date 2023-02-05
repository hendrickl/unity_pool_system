using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{
    [SerializeField] private GameObject _objectToPool;
    private List<GameObject> _pool = new List<GameObject>();
}
