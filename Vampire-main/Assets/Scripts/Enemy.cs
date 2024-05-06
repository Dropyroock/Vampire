//using System.Collections;
using System;
using System.Collections.Generic;
using Unity.Mathematics;

//using System.Numerics;

using UnityEngine;
//using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    SoundPlayer soundPlayer;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    public GameObject coinObject;
    public GameObject gemObject;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Start() 
    {
        target = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player_Mouvement.getInstance()AddExp();
        if(collision.gameObject.CompareTag("Weapon"))
        {
            SoundPlayer.GetInstance().PlayDeathAudio();
            Destroy(gameObject);
            DropGem();
            DropCoin();
        }
     }

    public void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position- transform.position).normalized;
            moveDirection = direction;
        }
    }

    public void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    void DropCoin()
    {
        Vector3 position = transform.position;
        GameObject coin = Instantiate(coinObject, position,quaternion.identity);
        coin.SetActive(true);
    }

        void DropGem()
    {
        Vector3 position = transform.position;
        GameObject gem = Instantiate(gemObject, position,quaternion.identity);
    }
}
