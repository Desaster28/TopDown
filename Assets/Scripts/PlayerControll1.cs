using System.Collections;
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
    [Header("Leveling")]
    public int playerLevel = 1;
    public int playerExp = 0;
    public int expRequiredForLeveling = 10;
    public int maxLevel;
    public  Vector2 moveInput;
    public GameManager MyGameManager;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Unser Health is " + health);
        healthBar.value = health;
    }
    public void damageIntake(int i)
    {

        health -= i;
        healthBar.value = health;
        if(rb.transform.localScale.x <=0.001 )
        {
            Debug.Log("Death:::::");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            MyGameManager.EndGame();
            int myHighScore = MyGameManager.getScore();
            Debug.Log(myHighScore);
        }
        else{rb.transform.localScale -= new Vector3(0.005f, 0.005f, 0);}
        //rb.transform.localScale *= 0.01f;//
        //WE DONT USE HEALTH SYSTEM ANYMORE !!!! !! !!!!
        //if (health < 1)
        //{
            
        //    Instantiate(deathEffect, transform.position, Quaternion.identity);
            
        //}


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
            if (expRequiredForLeveling == playerExp)
            {
                
                playerExp = 0;
            }
            
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
