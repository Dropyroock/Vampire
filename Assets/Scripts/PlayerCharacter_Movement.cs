using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerCharacter_Movement : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] GameObject scythePrefab;
    [SerializeField] float scytheTimer = 2;
    float currentScytheTimer;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentScytheTimer -= Time.deltaTime;
        if (currentScytheTimer <= 0)
        {
            //spawn le scythe
            for (int i = 0; i < 3; i++) 
            {
                Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360f));
                //Instantiate(scythePrefab, transform.position, Quaternion.identity);
                GameObject scythe = ObjectPool.GetInstance().GetPooledObject();
                scythe.transform.SetPositionAndRotation(transform.position, rot);
                scythe.SetActive(true);
            }
            currentScytheTimer += scytheTimer; 
        }
          
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x, y) * movespeed;
    }
}
