using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerControll : MonoBehaviour
{
    public float speed;
    public int health = 5;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Camera cam;
    Vector2 mousePos;    
    public GameObject deathEffect;
    public Canvas Healthbar;
    public Sprite LifeIsTrue;
    public Sprite LifeIsFalse;
    [Header("Leveling")]
    public int playerLevel = 1;
    public int playerExp = 0;
    public int expRequiredForLeveling = 10;
    public int maxLevel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void damageIntake(int i)
    {
        if (health < 1)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log(health);
            health -= i;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("PickUp"))
         {
            playerExp += 1;
            if (expRequiredForLeveling == playerExp)
            {
                Debug.Log("Level up");
                playerExp = 0;
            }
            
             Destroy(other.gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        //rb.velocity = moveVelocity;
        Vector2 lookDir = mousePos - rb.position;
        float rotate = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        //rb.rotation = rotate;
    }
}
