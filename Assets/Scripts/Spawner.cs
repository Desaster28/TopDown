using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawn;
    // NEW SPAWN VARS
    public GameObject[] TheEnemy;
    public int xPos;
    public int yPos;
    public int RandEnemy;
    public int EnemyCount;

    IEnumerator EnemyDrop()
    {
        while (EnemyCount < 10)
        {
            Debug.Log(EnemyCount);
            xPos = Random.Range(-55,56);
            yPos = Random.Range(-55,56);
            RandEnemy = Random.Range(0,TheEnemy.Length+1);
            Instantiate(TheEnemy[RandEnemy], new Vector2(xPos, yPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            EnemyCount += 1;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
       // timeBtwSpawns = startTimeBtwSpawn;
        StartCoroutine(EnemyDrop());
    }
    public void EnemyCountDecrease(){
        if(EnemyCount<1){

        }else{
            EnemyCount--;
        }
    }
    // Update is called once per frame
    /*void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length-1);
            Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }*/
}
