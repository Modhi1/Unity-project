using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float strength = 5f;
    public float gravity = -9.81f;
    //public float tilt = 5f;

    private Vector3 direction;



    private void OnEnable()
    {
        // get the Vector3 of the current game object (position inside the game)
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        // space or left mouse is clicked 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // change the postion/jump up with the specified strength amount
            direction = Vector3.up * strength;
        }

        // incase nothing was click -> make player go down by the force of gravity 
        // Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Tilt the player based on the direction
       /* Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;*/
    }


    // for triggering the box colliders2D
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // FindObjectOfType is not the best way
            // method in GameManager class 
            FindObjectOfType<GameManager>().GameOver();
            
        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            // method in GameManager class 
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    

}
