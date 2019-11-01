using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : Enemy
{   
    public float speedo;
 



    protected override void Start()
    {
        health = 1;
        rbe = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        MyGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        setProperties();
    }
    
    void Update()
    {
        isColliding = false;
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedo * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            player.damageIntake(5);
            KillCurentEnemy();
            MyGameManager.ScoreUp(70);
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
            MyGameManager.ScoreUp(20);


        }
    }


    private void setProperties()
    {
        Vector3 temp = transform.localScale;
        temp.x *= playerPos.localScale.x;
        temp.y *= playerPos.localScale.y;
        transform.localScale = temp;
    }
}
