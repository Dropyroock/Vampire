using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : BaseWeapon
{
    [Header("Scythe prefab")] 
    [SerializeField] GameObject axePrefab;
    [Header("Scythe next spawn")] 
    [SerializeField] float axeTimer = 2;
    float currentAxeTimer;

    private void Update()
    {
        
        currentAxeTimer -= Time.deltaTime;
        if (currentAxeTimer <= 0)
        {
            //spawn le Axe
            for (int i = 0; i < 1; i++) 
            {

                Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360f));

                axePrefab.transform.SetPositionAndRotation(transform.position , rot);
                axePrefab.transform.right = Vector3.right * Player.GetInstance().transform.localScale.x;
                ObjectPoolManager.SpawnObject(axePrefab, transform.position, Quaternion.identity);//new

            }
            //Axe timer for next spawn
            currentAxeTimer += axeTimer; 
        }
          
    }
}


