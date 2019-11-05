using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    private float nextFire;
    
    public float fireRate;
    public GameObject bullet;
    private Rigidbody2D player;
    void Start()
    {
        nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Vector2 lookDir = this.transform.position - new Vector3(player.position.x, player.position.y, 0);
            float rotate = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg + 90f;
            Instantiate(bullet, transform.position, Quaternion.AngleAxis(rotate, Vector3.forward));
            nextFire = Time.time + fireRate;
        }
    }
}
