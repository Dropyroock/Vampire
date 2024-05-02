using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolable
{
    void Reset();
}
public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectToPool;
    [SerializeField] int poolCount = 100;
    List<GameObject> pooledOjects = new();
    private static ObjectPool instance;

    public static ObjectPool GetInstance() => instance;
    int poolIndex;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < poolCount; i++)
        {
            //Same
            //pooledOjects.Add(Instantiate(objectToPool, Vector3.zero, Quaternion.identity, transform));
            GameObject g = (Instantiate(objectToPool, Vector3.zero, Quaternion.identity, transform));
            g.SetActive(false);
            pooledOjects.Add(g);
        }
    }

    public GameObject GetPooledObject() 
    {
        poolIndex %= poolCount;
        GameObject p = pooledOjects[poolIndex++];
        p.GetComponent<IPoolable>().Reset();
        return p;
    }
}
