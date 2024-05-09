using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();
    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.Lookupstring == objectToSpawn.name);

        // PooledObjectInfo pool = null;
        // foreach (PooledObjectInfo p in ObjectPools)
        // {
        //     if (p.Lookupstring == objectToSpawn.name)
        //     {
        //         pool = p;
        //         break;
        //     }
        // }

        // Si le pool nexiste pas, le creer
        if(pool == null)
        {
            pool = new PooledObjectInfo() {Lookupstring = objectToSpawn.name};
            ObjectPools.Add(pool);
        }

        // Verifier si il y a des obj inactif dans le pool
        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

        // GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();
        // foreach (GameObject obj in pool.InactiveObjects)
        // {
        //     if (obj != null)
        //     {
        //         spawnableObj = obj;
        //         break;
        //     }
        // }

        if (spawnableObj == null)
        {
            // Si il y a pas d'obj inactif, en creer de nouveau
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
        }

        else 
        {
            // Si il y a des obj inactif, le reactiver
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length -7); // On retire 7 lettre du nom de lobj pour retirer (Clone)
        PooledObjectInfo pool = ObjectPools.Find(p => p.Lookupstring == goName);
        if (pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled " + obj.name);
        }
        else 
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }
}

public class PooledObjectInfo
{
     public string Lookupstring;
     public List<GameObject> InactiveObjects = new List<GameObject>();
}
