using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpeedDestroy : MonoBehaviour
{

    private TimeDeltaTime timer;
    private float destroyXposition = -20;
    private float increaseSpeed;
    public float spoeedmulti = 0.8f;

    void Start()
    {
        timer = FindObjectOfType<TimeDeltaTime>();
        StartCoroutine(Check());
    }

    void Update()
    {

        transform.Translate(Vector3.left * (timer.speed001 * spoeedmulti) * Time.deltaTime);
        /*if (transform.position.x <= destroyXposition)
        {
            Destroy(gameObject);
        }*/
    }
    IEnumerator Check()
    {
        while (true)
        {

            if (transform.position.x <= destroyXposition)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
