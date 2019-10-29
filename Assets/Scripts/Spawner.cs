using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] spawnSpots;
    // NEW SPAWN VARS
    public GameObject[] TheEnemy;
    public int xPos;
    public int yPos;
    public int RandEnemy;
    public int EnemyCount;
    public GameManager MyGameManager;
    IEnumerator EnemyDrop()
    {
        while (true)
        {            
            xPos = Random.Range(-55,56);
            yPos = Random.Range(-55,56);
            RandEnemy = Random.Range(0,TheEnemy.Length+1);
           /* GameObject go = Instantiate(TheEnemy[0], new Vector2(xPos, yPos), Quaternion.identity);
            go.GetComponent<Enemy>().spawnerScript=this;
            yield return new WaitForSeconds(0.1f);
            EnemyCount += 1;*/ 

    
            // First 10 Seconds normal Enemy
            Debug.Log(MyGameManager.getTime());
            //if(MyGameManager.getTime() > 10f){
                Debug.Log("In if");
                //GameObject first10Seconds = Instantiate(TheEnemy[0], new Vector2(xPos, yPos), Quaternion.identity);
                //first10Seconds.GetComponent<Enemy>().spawnerScript=this;
                yield return new WaitForSeconds(0.5f);
            //}

            //after 10s


            EnemyCount++;
            // Debug.Log(EnemyCount);


        }
    }

    public void SpawnBasicEnemy(){
        Instantiate(TheEnemy[0], new Vector3(Random.Range(-55,56), Random.Range(-55,56), 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        if(MyGameManager.getTime() > 10f){
            SecondWave();
            CancelInvoke("SpawnBasicEnemy");
            
        }
    }
    public void SecondWave()
    {
        Instantiate(TheEnemy[0], new Vector3(Random.Range(-55, 56), Random.Range(-55, 56), 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        if (MyGameManager.getTime() > 30f)
        {
            CancelInvoke("SecondWave");
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBasicEnemy();
        InvokeRepeating("SpawnBasicEnemy", 0, 0.5f);
       // timeBtwSpawns = startTimeBtwSpawn;
        //StartCoroutine(EnemyDrop());
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
