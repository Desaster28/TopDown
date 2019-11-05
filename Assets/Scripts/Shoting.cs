using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource sound;
    public PlayerControll player;
    public float bulletForce = 20f;

    //private Rigidbody2D rb;

    private void Start()
    {
        bulletPrefab.GetComponent<Rigidbody2D>().transform.localScale = player.transform.localScale / 7;
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            sound.Play();
        }
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb= bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        //player.DecreaseSize();
    }

    public void DecreaseBulletSize()
    {
        bulletPrefab.GetComponent<Rigidbody2D>().transform.localScale = player.transform.localScale / 7;
    }
}
