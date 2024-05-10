using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
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
            EXPManager.instance.AddExperience(value);
            gameObject.SetActive(false);
        }
    }
}
