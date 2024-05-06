using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using Unity.Mathematics;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject weakEnemy;
    [SerializeField] GameObject strongEnemy;

    private static EnemyFactory instance;
    public static EnemyFactory GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject CreateWeakEnemy()
    {
        return Instantiate(weakEnemy, Vector3.zero, Quaternion.identity);
    }

        public GameObject CreateStrongEnemy()
    {
        return Instantiate(strongEnemy, Vector3.zero, Quaternion.identity);
    }
}
