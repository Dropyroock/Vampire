//using System.Collections;
using System.Collections.Generic;
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
        SoundPlayer.GetInstance().PlayDeathAudio();
        Destroy(gameObject);
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
}
