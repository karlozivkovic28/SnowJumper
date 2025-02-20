using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject platform;
    public GameObject cloud;
    public float spawnRate;
    private float timer = 0;
    public float spawnRate2;
    private float timer2 = 0;
    public float spawnOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn(platform, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Spawnrate(platform, ref timer, spawnRate, 0);
        Spawnrate(cloud, ref timer2, spawnRate2, 1);
    }
    void Spawnrate(GameObject objects, ref float timer, float spawnRate, int z)
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Spawn(objects, z);
            timer = 0;
        }
    }

    void Spawn(GameObject objects, int z)
    {
        float mostLeftPoint = transform.position.x - spawnOffset;
        float mostRightPoint = transform.position.x + spawnOffset;

        Instantiate(objects, new Vector3(Random.Range(mostLeftPoint, mostRightPoint), transform.position.y, z), transform.rotation);
    }
}
