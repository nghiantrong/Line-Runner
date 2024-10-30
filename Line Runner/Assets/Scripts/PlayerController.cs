using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerYPos;
    void Start()
    {
        playerYPos = transform.position.y;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            playerYPos = -playerYPos;

            transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);
        }
    }
}
