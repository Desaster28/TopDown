using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactSpawner : MonoBehaviour
{
    //public GameObject[] sprite;
    public Sprite[] sprite;
    
    public void SpawnArtifacts(int x, int y, int amount)
    {
        int xRange = x + Random.Range(-5, 5);
        int yRange = y + Random.Range(-5, 5);
        Vector3 spownPosition = new Vector3(xRange, yRange, 0);
        Instantiate(sprite[Random.Range(0, sprite.Length - 1)], spownPosition, Quaternion.identity);
    }

}
