using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundSpeedDestroy : MonoBehaviour
{

    private TimeDeltaTime timer;
    private float destroyXposition = -25;
    private float destroyYposition = -8;
    private float increaseSpeed;

    void Start()
    {
        timer = FindObjectOfType<TimeDeltaTime>();
        StartCoroutine(Check());
    }
    private void Update()
    {
        transform.Translate(Vector3.left * (timer.speed002) * Time.deltaTime);
    }
    /* void Update()
     {
         //increaseSpeed = timer.speedIncrease;
 transform.Translate(Vector3.left * (timer.speed002) * Time.deltaTime);
  if (transform.position.x <= destroyXposition)
  {
      Destroy(gameObject);
  }

  if (transform.position.y<=destroyYposition)
  { Destroy(gameObject); }
}*/
    IEnumerator Check()
    {
        while (true)
        {
            //transform.Translate(Vector3.left * (timer.speed002) * Time.deltaTime);
            if (transform.position.x <= destroyXposition)
            {
                Destroy(gameObject);
            }

            if (transform.position.y <= destroyYposition)
            { Destroy(gameObject); }
            yield return new WaitForSeconds(1);
        }
    }
}