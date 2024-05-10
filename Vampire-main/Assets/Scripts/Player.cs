using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Player : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] BaseWeapon[] weapons;
    Rigidbody2D rb;
    [SerializeField] int maxHP;
    [SerializeField] int currentHp;
    private static Player exp;
    private static Player instance;
    public GameOverScreen GameOverScreen;
    public static Player GetInstance() => instance;
    
    private void Awake()
    {
        currentHp = maxHP;
        instance = this;
    }

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

    public void Damage(int value)
    {
        currentHp -= value;
        if(currentHp <=0)
        {
            Debug.Log("Game Over");
            GameOver();
        }
    }

    private void GameOver()
    {
        GameOverScreen.Setup(currentHp);
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x, y) * movespeed;
    }
}
