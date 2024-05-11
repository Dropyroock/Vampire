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
    [SerializeField] GameObject[] specialEnemy;
    [Header("Boss enemy")] 
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

    public GameObject CreateSpecialEnemy()
    {
        int randEnemy = Random.Range(0, specialEnemy.Length);
        return Instantiate(specialEnemy[randEnemy], Vector3.zero, Quaternion.identity);
    }

    public GameObject CreateBossEnemy()
    {
        int randEnemy = Random.Range(0, bossEnemy.Length);
        return Instantiate(bossEnemy[randEnemy], Vector3.zero, Quaternion.identity);
    }
}
