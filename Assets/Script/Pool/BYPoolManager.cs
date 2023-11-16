using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BYPoolManager : MonoBehaviour
{
    public static BYPoolManager Instance;

    [SerializeField] private GameObject _thugPrefab;
    [SerializeField] private int _poolSize ;

    [SerializeField] private List<GameObject> _objectPool;

    private void Awake()
    {
        Instance = this;
        CreatePool();
    }

    private void CreatePool()
    {
        _objectPool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject thug = Instantiate(_thugPrefab, Vector3.zero, Quaternion.identity);
            thug.SetActive(false);
            _objectPool.Add(thug);
        }
    }

    public GameObject GetThugFromPool()
    {
        foreach (GameObject thug in _objectPool)
        {
            if (!thug.activeInHierarchy)
            {
                return thug;
            }
        }

        GameObject newThug = Instantiate(_thugPrefab, Vector3.zero, Quaternion.identity);
        newThug.SetActive(false);
        _objectPool.Add(newThug);
        return newThug;
    }
    
    public void ReturnThugToPool(GameObject thug)
    {
        thug.SetActive(false);
    }
}
