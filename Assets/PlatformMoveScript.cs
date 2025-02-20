using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float speedIncreaseRate = 0.01f;
    public float bottomScreenY = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed += speedIncreaseRate * Time.deltaTime;

        transform.position += (Vector3.down * moveSpeed) * Time.deltaTime;

        if (transform.position.y < bottomScreenY) 
        {
            Destroy(gameObject);
        }
    }
}
