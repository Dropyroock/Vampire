using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : BaseWeapon
{
    [Header("Scythe prefab")] 
    [SerializeField] GameObject scythePrefab;
    [Header("Scythe next spawn")] 
    [SerializeField] float scytheTimer = 2;
    float currentScytheTimer;

    
    
    private void Update()
    {
        
        currentScytheTimer -= Time.deltaTime;
        if (currentScytheTimer <= 0)
        {
            //spawn le scythe
            for (int i = 0; i < 3; i++) 
            {
                //Give rand rot pos for right
                Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360f));
                
                //Instantiate(scythePrefab, transform.position, Quaternion.identity);
                //GameObject scythePrefab = ObjectPool.GetInstance().GetPooledObject();//needed
                scythePrefab.transform.SetPositionAndRotation(transform.position, rot);//needed
                ObjectPoolManager.SpawnObject(scythePrefab, transform.position, rot);//new

                //scythePrefab.SetActive(true);//needed
            }
            //Scyhte timer for next spawn
            currentScytheTimer += scytheTimer; 
        }
          
    }
}
