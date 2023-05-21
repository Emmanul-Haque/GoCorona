using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona_Player : MonoBehaviour
{

    public float speed;
    public float jump;

    public LayerMask platform;
    public LayerMask deathPlatform;

    private Rigidbody2D RD;
    private Collider2D Co;
    private Animator animator;

    public AudioSource deathSound;  
    public AudioSource jumpSound;

    public GameManager gameManager;



    void Start()
    {
        RD = GetComponent<Rigidbody2D>();
        Co = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(Co, deathPlatform);
        if (dead)
        {
            GameOver();
        }


        RD.velocity = new Vector2(speed, RD.velocity.y);

        bool head = Physics2D.IsTouchingLayers(Co, platform);

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (head)
            {
                jumpSound.Play();
                RD.velocity = new Vector2(RD.velocity.x, jump);

            }

        }

        animator.SetBool("head", head);
    }

    void GameOver()
    {
        gameManager.GameOver();
    }
}
