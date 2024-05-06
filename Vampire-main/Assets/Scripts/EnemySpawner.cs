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
                EnemyFactory.GetInstance().CreateWeakEnemy();
            }
            EnemyFactory.GetInstance().CreateStrongEnemy();
            yield return new WaitForSeconds(5);
        }
    } 

    Vector3 PickPointAroundPlayer()
    {
        Vector3 result = PlayerCharacter_Movement.GetInstance().transform.position;
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        result.x = randomPoint.x;
        result.y = randomPoint.y;
        return result;
    }
}
