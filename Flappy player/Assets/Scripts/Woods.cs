using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class id responsible of the movement of the woods on the x axis
public class Woods : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    public float speed = 5f;
    private float leftEdge;

    private void Start()
    {
        // Vector3.zero -> the left side
        // bring the left side of the camera (to know)
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // updated for every frame
    private void Update()
    {
        // change position of the wood
        // make it move to the left side
        transform.position += Vector3.left * speed * Time.deltaTime;

        // if the woods exceeds the left edge
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
