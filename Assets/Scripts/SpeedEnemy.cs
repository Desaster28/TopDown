﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : MonoBehaviour
{    
    private Transform playerPos;
    private PlayerControll player;

    public float speed;
    public int health = 1;
    public GameObject deathEffect;
    private Rigidbody2D rbe;
    private CircleCollider2D colider;
    public GameObject[] sprite;
    public Transform Player;
    public GameManager MyGameManager;
    public bool isColliding;
    private void Start()
    {
        rbe = GetComponent<Rigidbody2D>();
        colider = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        setProperties();
    }
    
    void Update()
    {
        isColliding = false;
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.GetType());
        //Debug.Log(typeof(CircleCollider2D));
        //if (other.GetType() == typeof(CircleCollider2D))
        //{ Debug.Log("AHALL"); }

        //Debug.LogWarning(other.tag);
        if (other.CompareTag("Player"))
        {
            
            player.damageIntake(5);
            KillCurentEnemy();
            MyGameManager.ScoreUp(50);
            Debug.Log("Ich bin in Player");

        }
        if (other.CompareTag("Fire"))
        {
            if (isColliding) return;
            isColliding = true;
            Debug.Log("Ich bin in Fire");

            //Debug.Log("HOWMANY");
            Destroy(other.gameObject);
            //other.GetComponent<Shoting>().DestroyBullet();
           // Debug.Log("HOWMANY2");
            KillCurentEnemy();
            MyGameManager.ScoreUp(50);


        }
    }

    private void KillCurentEnemy()
    {
        Destroy(this.gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
    }

    private void setProperties()
    {
        Vector3 temp = transform.localScale;
        temp.x *= Player.localScale.x;
        temp.y *= Player.localScale.y;
        transform.localScale = temp;
    }
}
