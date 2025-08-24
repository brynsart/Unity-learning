using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController5 : MonoBehaviour
{

    public float moveSpeed;

    float xInput;

    float yInput;

    Rigidbody rb;

    int score;

    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if(transform.position.y <= -5f)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }

    private void OnTriggerEnter(Collider other) // Function gets called whenever the ball collides with an object with a collider and trigger on. Have all information related to trigger inside other folder.
    {
        if(other.tag == "Coin")
        {
            score++;
            other.gameObject.SetActive(false);
        }

        if(score >= 11)
        {
            // Win game
            winText.SetActive(true);
        }
    }
}