using System.Collections;
//using System.Numerics;

//using System.Collections.Generic;
//using System.Numerics;
//using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Normal enemy")] 
    //[SerializeField] GameObject enemyPrefab;  
    [Header("Special enemy")] 
    //[SerializeField] GameObject[] bigEenemyPrefab;

    public float spawnInterval = 5;
    public float currentSpawnTime = 0;
    public float bigCountdown = 120;
    public float curretnBigTime = 0;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] GameObject player;

    [SerializeField] private float spawnTime = 5;


    private void Start() 
    {
        StartCoroutine(SpawnEnemy());
        
    }   
    
    public IEnumerator SpawnEnemy() 
    {
        while (true)
        {
            for (int i = 0; i < 10; i++) 
            {
                SpawnWeakAroundPlayer();
                
            }
            for (int i = 0; i < 2; i++)
            {
                SpawnStrongAroundPlayer();
            }

            yield return new WaitForSeconds(spawnTime);
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

        private void SpawnStrongAroundPlayer()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newStrongEnemy = EnemyFactory.GetInstance().CreateStrongEnemy();
        newStrongEnemy.transform.position = position;
        newStrongEnemy.GetComponent<Enemy>().SetTraget(player);
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
