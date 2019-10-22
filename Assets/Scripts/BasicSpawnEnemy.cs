using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawnEnemy : MonoBehaviour
{
    public float speed;
    public int health;
    public int spawnEnemies;
    public GameObject deathEffect;
    public GameObject enemyToSpawn;
    public GameObject[] sprite;

    private Transform playerPos;
    private PlayerControll player;   
    private Rigidbody2D rbe;
    private CircleCollider2D colider;
    private float radius;

    private void Start()
    {
        rbe = GetComponent<Rigidbody2D>();
        colider = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        radius = transform.localScale.magnitude;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        if (health < 1)
        {
            KillCurentEnemy();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //float sizeDifferance = (radius - playerPos.transform.localScale.magnitude);

            //Debug.Log("Float Size Differance: " + sizeDifferance);
            //Debug.Log("Int Size Differance: " + Mathf.RoundToInt(sizeDifferance));

            //if (sizeDifferance <= 1 || sizeDifferance >= -1)
            //{
            //    Debug.Log("Draw");
            //    player.damageIntake(1);
            //    health--;
            //}
            //else if (sizeDifferance > 0)
            //{
            //    Debug.Log("Enemy");
            //    player.damageIntake(Mathf.RoundToInt(sizeDifferance));
            //    Debug.Log(sizeDifferance);
            //}
            //else
            //{
            //    Debug.Log("Player");
            //    health += Mathf.RoundToInt(sizeDifferance);
            //    Debug.Log(sizeDifferance);
            //}

            float playerRadius = playerPos.transform.localScale.magnitude;
            float sum = radius + playerRadius;
            float playerPercentage = (playerRadius * 100) / sum;
            float enemyPercentage = (radius * 100) / sum;

            if(playerPercentage < enemyPercentage)
            {
                Debug.Log("Player took" + Mathf.RoundToInt(enemyPercentage));
            }
        }
        if (other.CompareTag("Fire"))
        {
            health--;

            Destroy(other.gameObject);
            
        }
    }

    private void KillCurentEnemy()
    {
        SpawnArtifacts(rbe.position.x, rbe.position.y, 3);
        SpownBssicEnemy(rbe.position.x, rbe.position.y, spawnEnemies);
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

    }

    public void SpawnArtifacts(float x, float y, int amount)
    {
        while (amount > 0)
        {
            float xRange = x + Random.Range(-3f, 3f);
            float yRange = y + Random.Range(-3f, 3f);
            Vector2 spownPosition = new Vector2(xRange, yRange);
            GameObject artifact = Instantiate(sprite[Random.Range(0, sprite.Length - 1)], spownPosition, Quaternion.identity);
            artifact.transform.localScale = (artifact.transform.localScale + this.transform.localScale) / 5f;
            amount--; 
        }

    }

    private void SpownBssicEnemy(float x, float y, int amountOfEnemiesToSpawn)
    {       
        for (int i = 0; i < amountOfEnemiesToSpawn; i++)
        {
            float xRange = x + Random.Range(-radius, radius);
            float yRange = y + Random.Range(-radius, radius);
            Vector2 spownPosition = new Vector2(xRange, yRange);
            GameObject artifact = Instantiate(enemyToSpawn, spownPosition, Quaternion.identity); 
        }
    }
}
