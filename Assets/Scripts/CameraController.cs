using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offsetValue;

    public GameManager gm;

    void Update()
    {
        // Sets an offest to the direction the player is facing
        Vector3 offset = player.transform.up;

        // Moves camera to a possition in front of the player
        transform.position = player.transform.position + offset.normalized * offsetValue + new Vector3(0,0,-10);

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -gm.xBounds, gm.xBounds), Mathf.Clamp(transform.position.y, -gm.yBounds, gm.yBounds), transform.position.z);
    }
}
