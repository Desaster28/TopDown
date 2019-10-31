using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    public float delay;


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private Camera mainCamera;
    private float currentCameraDistance;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        mainCamera = GetComponent<Camera>();
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {       
        Vector3 cameraOffset = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        //transform.position = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, cameraOffset, delay * Time.deltaTime);
    }
}