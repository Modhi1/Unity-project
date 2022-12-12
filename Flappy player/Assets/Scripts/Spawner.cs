using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is for creating woods that are placed randomly on the y axis
public class Spawner : MonoBehaviour
{

    // ref to Woods prefab
    public GameObject prefab;

    // rate for spawning prefab
    public float spawnRate = 1f;

    // for the range that will be used to randomly place the wood 
    public float minHeight = 2f;
    public float maxHeight = 8f;


    // when start the game + player didn't lose yet
    // when script is enabled 
    private void OnEnable()
    {
        //                 methodName,   time   , repeatRate
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // when player losses
    // when script is disabled 
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }


    private void Spawn()
    {
        // Quaternion.identity means no rotation
        //                           gameObject,    position     , rotation
        GameObject woods = Instantiate(prefab, transform.position, Quaternion.identity);

        // change the position randomly on the y axis 
        woods.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);


    }
}
