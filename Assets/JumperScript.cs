using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumperScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public float moveSpeed;
    public CounterScript counter;
    public bool jumperIsAlive = true;

    private bool isGrounded = true;
    private float screenWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<CounterScript>();

        screenWidth = Camera.main.orthographicSize * 2f * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumperIsAlive) 
        {
            HandleMovement();
            HandleScreenBounds();
        }
    }

    private void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigidbody.linearVelocity += Vector2.up * jumpStrength;
        }
 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidbody.linearVelocity += Vector2.left * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidbody.linearVelocity += Vector2.right * moveSpeed;
        }
    }

    private void HandleScreenBounds()
    {
        if (transform.position.x > screenWidth / 2)
        {
            transform.position = new Vector2(-screenWidth / 2, transform.position.y);
        }
        else if (transform.position.x < -screenWidth / 2)
        {
            transform.position = new Vector2(screenWidth / 2, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallZone")) 
        {
            counter.GameOver();
            jumperIsAlive = false;
        }
        if (collision.CompareTag("Upper"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Upper"))
        {
            isGrounded = false;
        }
    }
}
