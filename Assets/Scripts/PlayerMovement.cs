using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private KeyCode lastPressed;
    public float speed;
    public Rigidbody rb;

    private bool movingLeft = false;
    private bool movingRight = false;
    private bool movingUp = false;
    private bool movingDown = false;
    private float destination = 0; // moving destination

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            lastPressed = KeyCode.None;
        }

        if (movingLeft && transform.position.x <= destination)
        {
            transform.position = new Vector3(destination, transform.position.y, transform.position.z);
            rb.velocity = new Vector3(0, 0, 0);
            movingLeft = false;
        }
        else if (movingRight && transform.position.x >= destination)
        {
            transform.position = new Vector3(destination, transform.position.y, transform.position.z);
            rb.velocity = new Vector3(0, 0, 0);
            movingRight = false;
        }
        else if (movingUp && transform.position.z >= destination)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, destination);
            rb.velocity = new Vector3(0, 0, 0);
            movingUp = false;
        }
        else if (movingDown && transform.position.z <= destination)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, destination);
            rb.velocity = new Vector3(0, 0, 0);
            movingDown = false;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(movingDown || movingLeft || movingRight || movingUp))
        {
            if (Input.GetKey(KeyCode.LeftArrow) && lastPressed != KeyCode.LeftArrow)
            {
                if (transform.position.x > -10)
                {
                    movingLeft = true;
                    destination = transform.position.x - 5f;
                    rb.velocity = new Vector3(-speed, 0, 0);
                    lastPressed = KeyCode.LeftArrow;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) && lastPressed != KeyCode.RightArrow)
            {
                if (transform.position.x < 10)
                {
                    movingRight = true;
                    destination = transform.position.x + 5f;
                    rb.velocity = new Vector3(speed, 0, 0);
                    lastPressed = KeyCode.RightArrow;
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow) && lastPressed != KeyCode.UpArrow)
            {
                movingUp = true;
                destination = transform.position.z + 5f;
                rb.velocity = new Vector3(0, 0, speed);
                lastPressed = KeyCode.UpArrow;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && lastPressed != KeyCode.DownArrow)
            {
                if (transform.position.z > -5)
                {
                    movingDown = true;
                    destination = transform.position.z - 5f;
                    rb.velocity = new Vector3(0, 0, -speed);
                    lastPressed = KeyCode.DownArrow;
                }
            }
        }
        
    }
}
