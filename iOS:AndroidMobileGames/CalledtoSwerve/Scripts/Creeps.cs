using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeps : MonoBehaviour
{
    //Speed for creeps
    public float speed = 5f;
    //Will be used to store for the left position of the screen
    private float leftEdge;

    //Calculate position of the left edge
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    //Move the creeps to the left, and destroy them at left edge
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
