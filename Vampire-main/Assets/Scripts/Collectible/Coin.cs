using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] public int value;
    float lifetime = 10f;
    private Rigidbody2D rb;

        private Coroutine _returnToPoolTimeCoroutine;
    
    public void Reset() 
    {
        lifetime = 10f;
    }

        private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     lifetime -= Time.deltaTime;
    //     if(lifetime < 0) 
    //     {
    //         gameObject.SetActive(false);
    //     }
    // }

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject);
            ObjectPoolManager.ReturnObjectToPool(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
            gameObject.SetActive(false);
        }
    }
}
