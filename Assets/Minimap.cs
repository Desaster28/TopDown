using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform Player;

    private void LateUpdate()
    {
        Vector2 newPosition = Player.position;
        newPosition.y = transform.position.y;
        newPosition.x = transform.position.x;
        transform.position = newPosition;
    }
}
