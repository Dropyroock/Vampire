using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    protected int level;

    public virtual void LevelUP()
    {
        level++;
        gameObject.SetActive(true);
    }
}
