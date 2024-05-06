using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerCharacter_Movement : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] BaseWeapon[] weapons;
    Rigidbody2D rb;
    private static Player_Mouvement instance;
    private static Player_Mouvement exp;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapons[0].LevelUP();
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[1].LevelUP();
        }
    }

    // internal void AddExp()
    // {
    //     exp++;
    //     if(exp % 5 == 0)
    //     {
    //         weapons[UnityEngine.Random.value]
    //     }

    // }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x, y) * movespeed;
    }
}
