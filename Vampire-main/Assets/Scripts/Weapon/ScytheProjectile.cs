using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScytheProjectile : MonoBehaviour, IPoolable
{
    float lifetime = 2f;
    private Rigidbody2D rb;
    private Coroutine _returnToPoolTimeCoroutine;

    [SerializeField] private int damage;

    public void Reset() 
    {   
        lifetime = 2f;
    }

        private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Damage(damage);
        }
    }

    private void Update()
    {
        transform.position += 5f * Time.deltaTime * transform.right;
    }
}
