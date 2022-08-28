using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public float backgroundSize;
    private Transform cameraTransform;
    [SerializeField]
    private TimeDeltaTime Timer;
    private Transform[] layers;
    private float viewzone = 10;
    private int leftIndex;
    private int rightIndex;
    private float increaseSpeed;
    private float speed;
    public bool Speed001;
    public bool Speed002;
    public float Speedmultiplier = 1;
    private void Start()
    {
        Timer = FindObjectOfType<TimeDeltaTime>();
        if (Speed001)
        {
            speed = Timer.speed001;
            Speed002 = false;
        }
        else
        {
            speed = Timer.speed002;
            Speed001 = false;
            Speed002 = true;
        }
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }
    void Update()
    {
        SpeedCheck();
        transform.Translate(Vector3.left * (speed * Speedmultiplier) * Time.deltaTime);
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewzone))
            ScrollLeft();

        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewzone))
            ScrollRight();
    }
    private void ScrollLeft()
    {
        layers[rightIndex].position = new Vector3((layers[leftIndex].position.x - backgroundSize), layers[rightIndex].position.y, layers[rightIndex].position.z);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }
    private void ScrollRight()
    {
        layers[leftIndex].position = new Vector3((layers[rightIndex].position.x + backgroundSize), layers[leftIndex].position.y, layers[leftIndex].position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }

    public void SpeedCheck()
    {
        if (Speed001)
        {
            speed = Timer.speed001;
            Speed002 = false;
        }
        else
        {
            speed = Timer.speed002;
            Speed001 = false;
            Speed002 = true;
        }
    }
}