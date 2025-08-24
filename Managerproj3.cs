using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managerproj3 : MonoBehaviour
{

    GameObject[] cubes;

    public float waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        //DestroyAllCubes();

        //Invoke("DestroyAllCubes", 2f); // f for float value

        //StartCoroutine("DestroyCubes"); // Calling the code routine

        StartCoroutine(DestroyCubes(waitingTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyAllCubes()
    {
        cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach(GameObject g in cubes)
        {
            Destroy(g);
        }
    }

    IEnumerator DestroyCubes(float waitTime) // Code Routine
    {
        //yield return new WaitForSeconds(2);

        cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject g in cubes)
        {
            yield return new WaitForSeconds(waitTime);
            Destroy(g);
        }
    }
}