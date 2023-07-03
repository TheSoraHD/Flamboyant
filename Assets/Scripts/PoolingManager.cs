using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]

public class PooledItems
{
    public string Name;
    public GameObject ObjectToPool;
    public int Amount;
}

public class PoolingManager : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, List<GameObject>> m_items =
        new Dictionary<string, List<GameObject>>();
    private List<PooledItems> m_pooledLists = new List<PooledItems>();
    private static PoolingManager m_instance;
    public static PoolingManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<PoolingManager>();
            return m_instance;
        }
    }

    void Awake()
    {
        for (int i = 0; i < m_pooledLists.Count; i++)  //Para cada lista de objetos
        {
            PooledItems l = m_pooledLists[i];
            m_items.Add(l.Name, new List<GameObject>()); //creamos una entrada en 
                                                         //el Dictionary
            for (int j = 0; j < l.Amount; j++)    //y añadimos las copias
            {
                GameObject tmp;
                tmp = Instantiate(l.ObjectToPool);  //Aquí creamos la copia
                tmp.SetActive(false);  //la desactivamos
                m_items[l.Name].Add(tmp);   //y la añadimos a la lista
            }
        }
    }

    public GameObject GetPooledObject()
    {
        List<GameObject> tmp = m_items[name];
        for (int i = 0; i < tmp.Count; i++) {
            if (!tmp[i].activeInHierarchy)
                return tmp[i];
        }
        return null;
    }
}