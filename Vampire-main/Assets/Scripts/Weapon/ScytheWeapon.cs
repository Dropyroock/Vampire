using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : BaseWeapon
{
    [SerializeField] GameObject scythePrefab;
    [SerializeField] float scytheTimer = 2;
    float currentScytheTimer;
    
    private void Update()
    {
        currentScytheTimer -= Time.deltaTime;
        if (currentScytheTimer <= 0)
        {
            //spawn le scythe
            for (int i = 0; i < 8+level; i++) 
            {
                Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360f));
                
                //Instantiate(scythePrefab, transform.position, Quaternion.identity);
                GameObject scythe = ObjectPool.GetInstance().GetPooledObject();
                scythe.transform.SetPositionAndRotation(transform.position, rot);
                scythe.SetActive(true);
            }
            currentScytheTimer += scytheTimer; 
        }
          
    }
}
