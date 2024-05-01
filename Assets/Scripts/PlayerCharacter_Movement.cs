using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter_Movement : MonoBehaviour
{
    [SerializeField] private float movespeed = 2f;
    [SerializeField] GameObject scythePrefab;
    [SerializeField] float scytheTimer = 2;
    float currentScytheTimer;
    Rigidbody2D rb;
    // Start is called before the first frame update
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
            Instantiate(scythePrefab, transform.position, Quaternion.identity);
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
