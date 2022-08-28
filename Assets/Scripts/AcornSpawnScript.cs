using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawnScript : MonoBehaviour
{  
    public GameObject acorn;
    private float randomTime;
    private float randomY;
    public float maxY;
    public float minY;
    [SerializeField]
    private TimeDeltaTime Timer;
    
    void Start()
    {
        if (Timer == null)
        {
            Timer = FindObjectOfType<TimeDeltaTime>();
        }
        randomTime = Random.Range(2, 6);
        randomY = Random.Range(minY, maxY);
    }
  
    void Update()
    {
        if (!Timer.stop)
        {
            if (randomTime <= 0)
            {
                GameObject newObject = Instantiate(acorn, new Vector2(transform.position.x, randomY), Quaternion.identity);
                randomTime = Random.Range(2, 6);
                randomY = Random.Range(minY, maxY);
            }
            else { randomTime -= Time.deltaTime; }
        }
        else { return; }
    }
    public void Destroy() => Destroy(gameObject);
}