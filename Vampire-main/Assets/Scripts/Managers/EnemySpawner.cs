using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Normal enemy")] 
    [SerializeField] GameObject[] enemyPrefab;  
    [Header("Special enemy")] 
    [SerializeField] GameObject[] bigEenemyPrefab;

    public float spawnInterval = 5;
    public float currentSpawnTime = 0;
    public float bigCountdown = 120;
    public float curretnBigTime = 0;

    [SerializeField] private float spawnTime = 5;


    private void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }   
    
    public IEnumerator SpawnEnemy() 
    {
        currentSpawnTime += Time.deltaTime;
        curretnBigTime += Time.deltaTime;

        while (true)
        {
            for (int i = 0; i < 10; i++) 
            {
                EnemyFactory.GetInstance().CreateWeakEnemy();
            }
            for (int i = 0; i < 2; i++)
            {
                EnemyFactory.GetInstance().CreateStrongEnemy();
            }

            yield return new WaitForSeconds(spawnTime);
        }
    } 

    Vector3 PickPointAroundPlayer()
    {
        Vector3 result = Player.GetInstance().transform.position;
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        result.x = randomPoint.x;
        result.y = randomPoint.y;
        return result;
    }
}
