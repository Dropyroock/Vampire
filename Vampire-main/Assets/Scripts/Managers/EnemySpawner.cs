using System.Collections;
//using System.Numerics;

//using System.Collections.Generic;
//using System.Numerics;
//using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] GameObject enemyPrefab;  

    //[SerializeField] GameObject[] bigEenemyPrefab;

    [SerializeField] Vector2 spawnArea;
    [SerializeField] GameObject player;

    [Header("Normal enemy")] 
    [SerializeField] private float normalSpawnTime;
    [Header("Special enemy")] 
    [SerializeField] private float specialSpawnTime;
    [Header("Boss enemy")] 
    [SerializeField] private float bossSpawnTime;


    private void Start() 
    {
        StartCoroutine(SpawnNormalEnemy());
        StartCoroutine(SpawnSpecialEnemy());
        StartCoroutine(SpawnBossEnemy());
    }   
    
    public IEnumerator SpawnNormalEnemy() 
    {
        while (true)
        {
            yield return new WaitForSeconds(normalSpawnTime);
            //Spawns Normal Ennemies
            for (int i = 0; i < 10; i++) 
            {
                SpawnWeakAroundPlayer();
            }
            //yield return new WaitForSeconds(normalSpawnTime);
        }
} 

    public IEnumerator SpawnSpecialEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(specialSpawnTime);
            //Spawns Special Ennemies
            for (int i = 0; i < 2; i++)
            {
                SpawnSpecialAroundPlayer();
            }
            //yield return new WaitForSeconds(specialSpawnTime);
        }

    }

            
     public IEnumerator SpawnBossEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(bossSpawnTime);
            //Spawns Boss Ennemies
            for (int i = 0; i < 1; i++)
            {
                SpawnBossAroundPlayer();
            }
            //yield return new WaitForSeconds(bossSpawnTime);
        }

    }

    private void SpawnWeakAroundPlayer()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newWeakEnemy = EnemyFactory.GetInstance().CreateWeakEnemy();
        newWeakEnemy.transform.position = position;
        newWeakEnemy.GetComponent<Enemy>().SetTraget(player);
    }

        private void SpawnSpecialAroundPlayer()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newSpecialEnemy = EnemyFactory.GetInstance().CreateSpecialEnemy();
        newSpecialEnemy.transform.position = position;
        newSpecialEnemy.GetComponent<Enemy>().SetTraget(player);
    }

    private void SpawnBossAroundPlayer()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newBossEnemy = EnemyFactory.GetInstance().CreateBossEnemy();
        newBossEnemy.transform.position = position;
        newBossEnemy.GetComponent<Enemy>().SetTraget(player);
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = Random.value > 0.5f ? -1f : 1f;
        if(Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.y = spawnArea.x * f;
        }
        position.z = 0;

        return position;
    }
}
