using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    protected Transform playerPos;
    protected PlayerControll player;
    public int health = 2;
    public GameObject deathEffect;
    protected Rigidbody2D rbe;
    public GameObject[] sprite;
    public bool isColliding;
    public GameManager MyGameManager;

    
    protected virtual void Start()
    {
        rbe = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        MyGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        isColliding = false;
        //transform.position = Vector2.MoveTowards( transform.position, playerPos.position , speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        transform.position = Vector2.MoveTowards( transform.position, playerPos.position , speed * Time.deltaTime);
        rbe.velocity = new Vector2(0,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
           
            player.damageIntake(1);
            KillCurentEnemy();
        }
        if (other.CompareTag("Fire"))
        {
            health--;
            Debug.Log("TESTEREERERARAERA");
            Debug.Log(isColliding);
            if (isColliding) return;
                isColliding = true;
            Destroy(other.gameObject);
            if (health < 1)
            {                
                KillCurentEnemyWithArtifact();     
            }
            else{}
        }
    }

    protected void KillCurentEnemyWithArtifact()
    {
        SpawnArtifacts(rbe.position.x, rbe.position.y, Random.Range(1, 3));
        Destroy(gameObject);       
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //spawnerScript.EnemyCountDecrease();  
        MyGameManager.ScoreUp(50);
    }
    protected void KillCurentEnemy()
    {
        //SpawnArtifacts(rbe.position.x, rbe.position.y, 1);
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        //spawnerScript.EnemyCountDecrease();  
        MyGameManager.ScoreUp(10);
    }

    public void SpawnArtifacts(float x, float y, int amount)
    {   
        while(amount > 0)
        {
            float xRange = x + Random.Range(-0.5f, 0.5f);
            float yRange = y + Random.Range(-0.5f, 0.5f);
            Vector2 spownPosition = new Vector2(xRange, yRange);
            GameObject artifact =  Instantiate(sprite[Random.Range(0, sprite.Length - 1)], spownPosition, Quaternion.identity);
            artifact.transform.localScale =  (artifact.transform.localScale + this.transform.localScale) / 5f;

            amount--;
        }               
    }

}
