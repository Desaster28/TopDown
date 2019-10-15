using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Transform playerPos;
    private PlayerControll player;
    public int health = 2;
    public GameObject deathEffect;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
  //  public void takeDamage(int i)
   // {
   //     if (health > 0) { health-=i; Debug.Log(health); }
   //     else { Destroy(gameObject); }
   // }
    void Update()
    {
        transform.position = Vector2.MoveTowards( transform.position, playerPos.position , speed*Time.deltaTime);
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
<<<<<<< HEAD
            if(health < 1) 
            {
                
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
=======
            Destroy(other.gameObject);
            if (health < 1)
            {
                KillCurentEnemy();     

            }
            else{     }
            
>>>>>>> DimaFeature
        }
    }

    private void KillCurentEnemy()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);  
    }
}
