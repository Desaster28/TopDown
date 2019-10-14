using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 1;
    public Enemy monstr;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Destroy(gameObject);
       
    }
}
