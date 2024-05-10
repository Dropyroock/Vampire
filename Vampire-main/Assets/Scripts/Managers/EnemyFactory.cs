using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using Unity.Mathematics;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [Header("Normal enemy")] 
    [SerializeField] GameObject[] weakEnemy;
    [Header("Special enemy")] 
    [SerializeField] GameObject[] strongEnemy;
    
    [SerializeField] GameObject[] bossEnemy;

    private static EnemyFactory instance;
    public static EnemyFactory GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject CreateWeakEnemy()
    {
        int randEnemy = Random.Range(0, weakEnemy.Length);
        return Instantiate(weakEnemy[randEnemy], Vector3.zero, Quaternion.identity);
    }

        public GameObject CreateStrongEnemy()
    {
        int randEnemy = Random.Range(0, strongEnemy.Length);
        return Instantiate(strongEnemy[randEnemy], Vector3.zero, Quaternion.identity);
    }

            public GameObject CreateBossEnemy()
    {
        int randEnemy = Random.Range(0, bossEnemy.Length);
        return Instantiate(bossEnemy[randEnemy], Vector3.zero, Quaternion.identity);
    }
}
