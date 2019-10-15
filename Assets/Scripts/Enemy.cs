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
    private Rigidbody2D rbe;
    public GameObject[] sprite;

    private void Start()
    {
        rbe = GetComponent<Rigidbody2D>();
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
        transform.position = Vector2.MoveTowards( transform.position, playerPos.position , speed * Time.deltaTime);
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

            Destroy(other.gameObject);
            if (health < 1)
            {
                KillCurentEnemy();     
            }
            else{}
        }
    }

    private void KillCurentEnemy()
    {
        SpawnArtifacts(rbe.position.x,rbe.position.y,1);
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);  
       
    }       
    
    public void SpawnArtifacts(float x, float y, int amount)
    {   
        float xRange = x + Random.Range(-2f, 2f);
        float yRange = y + Random.Range(-2f, 2f);
        Vector2 spownPosition = new Vector2(xRange, yRange);
        GameObject artifact =  Instantiate(sprite[Random.Range(0, sprite.Length - 1)], spownPosition, Quaternion.identity);
        artifact.transform.localScale =  (artifact.transform.localScale + this.transform.localScale) / 5f;
       
    }

}
