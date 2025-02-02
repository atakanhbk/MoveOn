using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public string poolName;
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


    public GameObject GetPooledObject(string objectType)
    {
        int objectTypeIndex = 0;
        objectType = objectType.ToLower();
        for (int i = 0; i < pools.Length; i++)
        {
            if (objectType == pools[i].poolName.ToLower())
            {
                objectTypeIndex = i;
            }
        }

        GameObject obj = pools[objectTypeIndex].objectPool.Dequeue();
        obj.SetActive(true);
        pools[objectTypeIndex].objectPool.Enqueue(obj);
        return obj;
    }

}
