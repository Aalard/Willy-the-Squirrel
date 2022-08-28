using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public bool grounded = true;
    public void OnTriggerEnter2D(Collider2D groundcheck)
    {
        if (groundcheck != null)
            grounded = true;
    }
    public void OnTriggerStay2D(Collider2D groundcheck)
    {
        if (groundcheck != null)
            grounded = true;
    }
    public void OnTriggerExit2D(Collider2D groundcheck)
    {
        grounded = false;
    }
}