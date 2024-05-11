using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Somthing : MonoBehaviour
{
    float lifetime = 0.1f;
    private Coroutine _returnToPoolTimeCoroutine;
    private Rigidbody2D rb;

    public void Reset() 
    {
        lifetime = 0.1f;
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
}
