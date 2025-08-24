using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2 : MonoBehaviour
{
    public GameObject ball; // GameObject will store ball reference to our in-game object
    public Transform spawnPoint;
    public float maxX;
    public float maxZ;
    public float zInp;
    public int speed;

    private List<Rigidbody> spawnedBalls = new List<Rigidbody>(); // List to keep track of spawned balls' Rigidbodies

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBall", 1f, 2f); // Will start calling the function after 1 second and will repeat every 2 seconds
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }

        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            zInp = Input.GetAxis("Vertical");

            Debug.Log("Mouse button clicked. Applying force...");

            // Apply force to all spawned balls
            foreach (Rigidbody rb in spawnedBalls)
            {
                if (rb != null)
                {
                    rb.AddForce(new Vector3(0, 0, zInp * speed), ForceMode.Impulse);
                    Debug.Log("Force applied to ball: " + rb.gameObject.name);
                }
            }
        }
    }

    void SpawnBall()
    {
        float randomX = Random.Range(-maxX, maxX);
        float randomZ = Random.Range(-maxZ, maxZ);

        Vector3 randomSpawnPos = new Vector3(randomX, 10f, randomZ); // X,Y,Z
        GameObject newBall = Instantiate(ball, randomSpawnPos, Quaternion.identity); // Ball is spawned, at spawn point position, and Zero rotation

        // Get the Rigidbody component of the spawned ball and add it to the list
        Rigidbody newBallRb = newBall.GetComponent<Rigidbody>();
        if (newBallRb != null)
        {
            spawnedBalls.Add(newBallRb);
            Debug.Log("Ball spawned and Rigidbody added: " + newBall.name);
        }
        else
        {
            Debug.LogError("Spawned ball does not have a Rigidbody component!");
        }
    }
}