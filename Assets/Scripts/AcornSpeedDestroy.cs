using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpeedDestroy : MonoBehaviour
{
    private TimeDeltaTime timer;
    private float destroyXposition = -20;
    private float increaseSpeed;
    //public GameObject destroyeffect;
    [SerializeField]
    private bool gravity=false;
    public float gravitymin = 1;
    public float gravirymax = 1.5f;
    private float gravityw;
  
    void Start()
    {
        timer = FindObjectOfType<TimeDeltaTime>();
        gravityw = Random.Range(gravitymin, gravirymax);
        StartCoroutine(Check());
    }

    void Update()
    {

        if (gravity)
        {
            transform.Translate((-1 * (timer.speed002) * Time.deltaTime), -1 * gravityw * Time.deltaTime, 0, Space.World);
        }
        else
        {
            transform.Translate((-1 * (timer.speed002) * Time.deltaTime), 0, 0, Space.World);
        }
        /* if (transform.position.x <= destroyXposition)
         {
             Destroy(gameObject);
         }
         if (transform.position.y <= -8)
         {
             Destroy(gameObject);
         }*/
    }
         IEnumerator Check()
         {
             while (true)
             {
                 //transform.Translate(Vector3.left * (timer.speed002) * Time.deltaTime);
                 if (transform.position.x <= destroyXposition)
                 {
                     Destroy(gameObject);
                 }
                 if (transform.position.y <= -8)
                 {
                     Destroy(gameObject);
                 }
                 yield return new WaitForSeconds(1);
             }
         }
     }

    /* void OnTriggerEnter2D(Collider2D player){
         if (player.tag=="Player"){
             Instantiate(destroyeffect, transform.position, Quaternion.identity);
             Destroy(gameObject);
         }
     }*/
    
