using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Queue<GameObject> objectPool;
    [SerializeField] private GameObject pref;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (objectPool == null)
            {
                objectPool = new Queue<GameObject>();
            }

            GameObject obj = Instantiate(pref);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        GameObject obj = objectPool.Dequeue();
        obj.SetActive(true);
        objectPool.Enqueue(obj);
        return obj;
    }

}
