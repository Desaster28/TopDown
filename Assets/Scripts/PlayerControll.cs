using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public float speed;
    public int health = 5;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Camera cam;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(health < 1)
        {
            Destroy(gameObject);
            Debug.Log("You Loose");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float rotate = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        rb.rotation = rotate;
    }
}
