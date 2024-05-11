//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    [SerializeField] GameObject weakPointPrefab;
    private EnemyWeakPoint weakpoint;

    private void Start()
    {
        weakpoint = Instantiate(weakPointPrefab, transform.position, Quaternion.identity).GetComponent<EnemyWeakPoint>();
        weakpoint.original = this;
    }

    public override void Die()
    {
        weakpoint.Die();
        base.Die();
    }
}
