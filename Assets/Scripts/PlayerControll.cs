using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerControll : MonoBehaviour
{
    public float speed;

    public int health;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Camera cam;
    Vector2 mousePos;    
    public GameObject deathEffect;
    public Vector2 moveInput;
    public GameManager MyGameManager;
    public Slider healthBar;
    public GameObject[] sprite;
    public float duration = 1.0f;
    private float elapsed = 0.0f;
    public Shoting shotingScript;
    [Header("Leveling")]
    public int playerLevel = 1;
    public int playerExp = 0;
    public int expRequiredForLeveling = 10;
    public int maxLevel;
    public bool GameOver;
    public PauseMenu ourPMenu;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        rb = GetComponent<Rigidbody2D>();

        //WE DONT USE HEALTH SYSTEM ANYMORE 

        // health = 100;
        // Debug.Log("Unser Health is " + health);
        // healthBar.value = health;
    }
    public void Wait(float seconds, Action action)
    {
        StartCoroutine(_wait(seconds, action));
    }
    IEnumerator _wait(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback();
    }
    private IEnumerator resizeRoutine(float oldSize, float newSize, float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            cam.orthographicSize = Mathf.Lerp(oldSize, newSize, t);
            yield return null;
        }
    }
    public void damageIntake(int i)
    {

        health -= i;
        healthBar.value = health;


        DecreaseSize();

    }

    public void DecreaseSize()
    {
        if (rb.transform.localScale.x <= 0.010)
        {
            Debug.Log("Death");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            ourPMenu.SetGameOver();
            Wait(0.50f, () => { MyGameManager.EndGame(); });
        }
        else
        {
            rb.transform.localScale -= new Vector3(0.0150f, 0.0150f, 0);
            Debug.Log(cam.orthographicSize);
            //cam.orthographicSize -= Mathf.Lerp(cam.orthographicSize,0.100f,5);
            elapsed += Time.deltaTime / duration;
            StartCoroutine(resizeRoutine(cam.orthographicSize, cam.orthographicSize - 0.1500f, 0.5f));

            //shotingScript.DecreaseBulletSize();
        }
        //rb.transform.localScale *= 0.01f;//


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        moveVelocity = moveInput.normalized * speed;
        if (Input.anyKey == false)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.zero);
            rb.angularVelocity = 0f;
            //Invoke("KinematicStop", 0.1f);
            //Invoke("KinematicOn", 0.1f);
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKey(KeyCode.E))
        {
            SpawnArtifacts((int)mousePos.x, (int)mousePos.y, 2);
            //this.GetComponent<ArtifactSpawner>().SpawnArtifacts((int)mousePos.x,(int)mousePos.y,2);
        }
    }
    public void SpawnArtifacts(float x, float y, int amount)
    {
        float xRange = x + UnityEngine.Random.Range(-0.5f, 0.5f);
        float yRange = y + UnityEngine.Random.Range(-0.5f, 0.5f);
        Vector2 spownPosition = new Vector2(xRange, yRange);
        GameObject artifact = Instantiate(sprite[UnityEngine.Random.Range(0, sprite.Length - 1)], spownPosition, Quaternion.identity);
        artifact.transform.localScale = (artifact.transform.localScale + this.transform.localScale) / 5f;

    }
    /*void KinematicStop()
    {
        rb.isKinematic = true;
    }
    void KinematicOn()
    {
        rb.isKinematic = false;
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("PickUp"))
         {
            MyGameManager.ScoreUp(10);
            playerExp += 1;
            rb.transform.localScale += new Vector3(0.005f,0.005f,0);
            Debug.Log(cam.orthographicSize);
            cam.orthographicSize += 0.150f;
            /*Debug.Log("DAS IST TEST");
            if (expRequiredForLeveling == playerExp)
            {
                
                playerExp = 0;
            }*/
            
             Destroy(other.gameObject);
        }
        
    }

    private void move(){
        rb.velocity = new Vector2(moveInput.x,moveInput.y)*speed;
    }
        private void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;
            move();
       // rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        //rb.velocity = moveVelocity;
        Vector2 lookDir = mousePos - rb.position;
        float rotate = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        float dist = Vector2.Distance(rb.position, mousePos);
        //Debug.Log(dist);
        if (dist > 0.2)
        {
            rb.rotation = (Mathf.LerpAngle(rb.rotation, Quaternion.AngleAxis(rotate, Vector3.forward).eulerAngles.z, 0.5f));
            //rb.rotation = rotate;
        }
        else { }
    }
}
