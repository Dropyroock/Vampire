using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemySpear : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private Coroutine _returnToPoolTimeCoroutine;
    float lifetime = 2f;
    [SerializeField] private int damage;

    public void Reset() 
    {   
        lifetime = 2f;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    private void Start()
    {
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = MathF.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnEnable()
    {
        _returnToPoolTimeCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    private IEnumerator ReturnToPoolAfterTime()
    {
        float elasedTime = 0f;
        while(elasedTime < lifetime)
        {
            elasedTime += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var Player))
        {
            Player.Damage(damage);
            Debug.Log("Dealt damage to player");
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
