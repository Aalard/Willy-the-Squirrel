using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpeednDestroy : MonoBehaviour
{
    public TimeDeltaTime timer;
    public float destroyXposition = -20;
    private float increaseSpeed;
    public bool playerCanDestroy = false;

    void FixedUpdate()
    {
        transform.Translate((-1 * (timer.speed002) * Time.deltaTime), 0, 0, Space.World);
        if (transform.position.x <= destroyXposition)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player" && playerCanDestroy)
        {
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}