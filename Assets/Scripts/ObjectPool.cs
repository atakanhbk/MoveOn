using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> objectPool;
        public GameObject pref;
        public int poolSize;
    }
    [SerializeField] private Pool[] pools = null;


    private void Awake()
    {

        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].objectPool == null)
            {
                pools[i].objectPool = new Queue<GameObject>();
            }

            for (int j = 0; j < pools[i].poolSize; j++)
            {

                GameObject obj = Instantiate(pools[i].pref);
                obj.SetActive(false);
                pools[i].objectPool.Enqueue(obj);
            }
        }
    }


    public GameObject GetPooledObject(int objectType)
    {

        if (objectType >= pools.Length)
        {
            return null;
        }
        GameObject obj = pools[objectType].objectPool.Dequeue();
        obj.SetActive(true);
        pools[objectType].objectPool.Enqueue(obj);
        return obj;
    }

}
