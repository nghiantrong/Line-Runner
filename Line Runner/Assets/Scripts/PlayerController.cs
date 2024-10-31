using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (GameManager.instance.gameStarted)
            {
                PositionSwitch();
            }

        }
    }

    void PositionSwitch()
    {
        playerYPos = -playerYPos;

        transform.position = new Vector3(transform.position.x,
            playerYPos, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.instance.UpdateLives();
        }
    }
}
