using System.Collections;
//using System.Collections.Generic;
//using System.Numerics;
//using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;  
    [SerializeField] GameObject[] bigEenemyPrefab;

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
                int randomIndex = Random.Range(0, enemyPrefab.Length);
                Vector2 randomSpwanPosition = new Vector2(Random.Range(-10,11), Random.Range(-10,11));
                Instantiate(enemyPrefab[randomIndex], new Vector3(3f, 3f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(5);
        }
    } 
}
