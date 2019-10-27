using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{


    public Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerRB.velocity = Vector3.zero;

    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerRB.velocity = Vector3.zero;
    }
    void Update()
    {
        
    }
}
