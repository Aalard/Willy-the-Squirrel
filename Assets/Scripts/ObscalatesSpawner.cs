using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObscalatesSpawner : MonoBehaviour
{
    public GameObject[] obscalates;
    private int randomObscalates;
    private float randomTime;
    [SerializeField]
    private TimeDeltaTime Timer;
    void Start()
    {
        randomObscalates = Random.Range(0, 9);
        randomTime = Random.Range(2, 4);
        Timer = FindObjectOfType<TimeDeltaTime>();
    }

    void Update()
    {
        if (!Timer.stop)
        {
            if (randomTime <= 0)
            {
                GameObject newObject = Instantiate(obscalates[randomObscalates], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                randomObscalates = Random.Range(0, 9);
                randomTime = Random.Range(2, 4);
            }
            else { randomTime -= Time.deltaTime; }
        }
        else { }
    }
    public void Destroy1()
    {
        Destroy(gameObject);
    }
}