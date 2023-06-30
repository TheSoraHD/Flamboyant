using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PoolingItems
{
    public string Name;
    public GameObject ObjectToPool;
    public int Amount;
}

public class PoolingManager : MonoBehaviour
{

    private static PoolingManager m_instance;
    public static PoolingManager Instance => m_instance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amount;

    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amount; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }
        return null;
    }

}
