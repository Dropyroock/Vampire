using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : BaseWeapon
{
    [SerializeField] GameObject axe;
    public override void LevelUP()
    {
        base.LevelUP();
        axe.transform.localScale = Vector3.one * (1 + 0.1f * level);
        
    }

    private void Update()
    {
        transform.Rotate(0,0,360 * Time.deltaTime);
    }
}
