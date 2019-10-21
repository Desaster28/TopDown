using System.Collections;
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
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            player.damageIntake(5);
            KillCurentEnemy();
        }
        if (other.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
            KillCurentEnemy();
        }
    }

    private void KillCurentEnemy()
    {
        Destroy(gameObject);
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
