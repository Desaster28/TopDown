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
        radius = colider.radius;
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
            OnCollisionWithPlayer();
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
            float spawnRadius = transform.localScale.magnitude;
            float xRange = x + Random.Range(-spawnRadius, spawnRadius);
            float yRange = y + Random.Range(-spawnRadius, spawnRadius);
            Vector2 spownPosition = new Vector2(xRange, yRange);
            GameObject artifact = Instantiate(enemyToSpawn, spownPosition, Quaternion.identity); 
        }
    }

    private void OnCollisionWithPlayer()
    {
        float playerRadius = playerPos.GetComponent<CircleCollider2D>().radius;
        float sum = radius + playerRadius;
        float playerPercentage = (playerRadius * 100) / sum;
        float enemyPercentage = (radius * 100) / sum;
        float difference = playerPercentage - enemyPercentage;

        if (difference <= 10 && difference >= -10)
        {
            health--;
            player.damageIntake(1);
        }
        else if (playerPercentage < enemyPercentage)
        {
            Debug.Log("Damage: " + Mathf.RoundToInt(enemyPercentage / 10));
            player.damageIntake(Mathf.RoundToInt(enemyPercentage / 10));
        }
        else
        {
            health -= Mathf.RoundToInt(playerPercentage / 10);
        }
    }
}
