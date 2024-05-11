// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

public class EnemyWeakPoint : Enemy
{
    public Enemy original;

    public override void Damage(int value)
    {
        original.Damage(value * 10);
    }
}
