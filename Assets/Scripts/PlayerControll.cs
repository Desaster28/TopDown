using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed;
    public int health = 5;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Camera cam;
    Vector2 mousePos;
    public int PlayerLvl,PlayerExp,maxLvl; //MIGHT BE CHANGED IN LVLUP SCRIPT !!!! 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void damageIntake(int i)
    {
        if (health < 1)
        {

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

    private void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float rotate = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        rb.rotation = rotate;
    }
}
