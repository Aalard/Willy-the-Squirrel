using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundSpawn : MonoBehaviour
{
    public GameObject Foreground;

    private float randomTime;
    [SerializeField]
    private TimeDeltaTime Timer;

    void Start()
    {
        Timer = FindObjectOfType<TimeDeltaTime>();
        randomTime = Random.Range(3, 12);
    }

    void Update()
    {
        if (!Timer.stop)
        {
            if (randomTime <= 0)
            {
                Instantiate(Foreground, transform.position, Quaternion.identity);
                randomTime = Random.Range(3, 12);
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