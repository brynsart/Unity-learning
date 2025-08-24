using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class code1 : MonoBehaviour
{

    Rigidbody rb;

    public GameObject winText;

    float xInput;
    float zInput;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 3f); // Just destroys the object allocated to this script: after 3 seconds

        rb = GetComponent<Rigidbody>(); // Getting access to rigid body attatched to game object
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // If space is pressed destroy object
        {
            //Destroy(gameObject);

            //rb.AddForce(Vector3.up * 500);
        }

        //rb.velocity = Vector3.forward * 20f;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Lev2");
        }

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, zInput * speed);
    }

    private void OnMouseDown() // Destroys object when mouse pressed down
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) // Collision contains the information within the collision
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            Destroy(collision.gameObject); // Will destroy the object colliding with the gameObject

            winText.SetActive(true);
        }
    }
}
