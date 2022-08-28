using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript1 : MonoBehaviour
{
    public GameObject[] cows;
    private int randomCow;
    private float randomTime;
    private float randomY;
    public float maxY;
    public float minY;
    [SerializeField]
    private TimeDeltaTime Timer;
    void Start()
    {
        Timer = FindObjectOfType<TimeDeltaTime>();
        randomCow = Random.Range(0, (cows.Length + 1));
        randomTime = Random.Range(2, 6);
        randomY = Random.Range(minY, maxY);
    }

    void Update()
    {
        if (!Timer.stop)
        {
            if (randomTime <= 0)
            {
                GameObject newObject = Instantiate(cows[randomCow], new Vector2(transform.position.x, randomY), Quaternion.identity);
                newObject.transform.localScale = new Vector3((1 + ((0.5f / (-minY + maxY)) * (maxY - newObject.transform.position.y))), (1 + ((0.5f / (-minY + maxY)) * (maxY - newObject.transform.position.y))), newObject.transform.localScale.z);
                randomCow = Random.Range(0, 4);
                randomTime = Random.Range(2, 6);
                randomY = Random.Range(minY, maxY);
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