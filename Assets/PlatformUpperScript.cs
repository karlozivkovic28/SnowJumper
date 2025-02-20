using UnityEngine;

public class PlatformUpperScript : MonoBehaviour
{
    public CounterScript counter;
    private bool hasLandedOnPlatform = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<CounterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && !hasLandedOnPlatform) 
        {
            counter.AddScore(1);
            hasLandedOnPlatform = true;
        }
    }
}
