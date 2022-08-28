using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnObject;
    private GameObject newObject;
    private int randomObject;
    public bool isRandomPosition = false;
    public bool isScaling = false;
    private float randomTime;
    private float randomY;
    public float maxY;
    public float minY;
    public float minTime = 2;
    public float maxTime = 4;
    //private float minTimeinit = 1;
    //private float maxTimeinit = 2;
    public bool isRandomX = false;
    public float minX;
    private float randomX;
    public bool israndomXspeed=false;
    public float maxX;
    [SerializeField]
    private TimeDeltaTime Timer;
    void Start()
    {
        if (Timer == null)
        {
            Timer = FindObjectOfType<TimeDeltaTime>();
        }
        newObject = spawnObject[0];
        Randomize();
    }

    public void Randomize()
    {
        randomObject = Random.Range(0, (spawnObject.Length));
        if (Timer.level == 0)
        {
            minTime = 2;
            maxTime = 3.5f;
        }
       else if ( Timer.level == 1)
        {
            minTime = 1.8f;
            maxTime = 3.2f;
        }
        else if (Timer.level == 2)
        {
            minTime = 1.6f;
            maxTime = 2.8f;
        }
        else if ( Timer.level == 3)
        {
            minTime = 1.4f;
            maxTime = 2.3f;
        }
        else if (Timer.level == 4)
        {
            minTime = 1.2f;
            maxTime = 1.8f;
        }
        else if (Timer.level == 5)
        {
            minTime = 0.9f;
            maxTime = 1.4f;
        }
        else { }
        randomTime = Random.Range(minTime, maxTime);
        if (isRandomPosition)
        {
            randomY = Random.Range(minY, maxY);
        }
        else { randomY = transform.position.y; }
        if (isRandomX)
        {
            if (!israndomXspeed) { randomX = Random.Range(minX, maxX); }
            else { randomX = Random.Range(minX+Timer.speed001-3, maxX+ Timer.speed001-3); }
            
        }
        else { randomX = transform.position.x; }
    }

    public void Spawn()
    {
        GameObject newObject = Instantiate(spawnObject[randomObject], new Vector2(randomX, randomY), Quaternion.identity);
        if (isScaling) { newObject.transform.localScale = new Vector3((newObject.transform.position.y + 3f) / (-2.5f), (newObject.transform.position.y + 3f) / (-2.5f), newObject.transform.localScale.z); }
        Randomize();
    }

    void Update()
    {
        if (!Timer.stop)
        {
            if (randomTime <= 0)
            {
                Spawn();
                
                //randomObject = Random.Range(0, (spawnObject.Length));
               /* if (minTime - Timer.speedIncrease >= minTimeinit && maxTime - Timer.speedIncrease >= maxTimeinit)
                {
                    randomTime = Random.Range(minTime - Timer.speedIncrease, maxTime - Timer.speedIncrease);
                }
                else { randomTime = Random.Range(minTimeinit, maxTimeinit); }*/
                //randomY = Random.Range(minY, maxY);
            }
            else { randomTime -= Time.deltaTime; }
        }
        else { return; }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}