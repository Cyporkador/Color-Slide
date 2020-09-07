using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private bool started = false;
    public Transform playerPos;
    public Rigidbody rb;
    public static int speed;
    private float timePassed = 0;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        rb.velocity = new Vector3(0, 0, speed);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started && Input.anyKeyDown)
        {
            Time.timeScale = 1;
            started = true;
        }
        timePassed += Time.deltaTime;
        if (playerPos.position.z - transform.position.z < 3.32 - 2)
        {
            GameMenuController.gameOver = true;
        }
        if (timePassed >= 30) // speed up every 30 seconds
        {
            speed += 1;
            rb.velocity = new Vector3(0, 0, speed);
            timePassed = 0;
            ProjectileGenerator.speed = speed / 2f * 10f * 0.75f;
            // Debug.Log(speed);
        }

        // speeds up the music
        if ((music.time >= 34.89 && music.time < 35) || (music.time >= 69.78 && music.time < 70) || (music.time >= 87.23 && music.time < 87.3))
        {
            music.pitch = 1 + ((speed - 2) * 0.05f);
        }
    }
}
