using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Examplestut8 : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    
    float xInput;

    bool flipX;

    public SpriteRenderer sprite;

    int score = 0;

    public Text scoreText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        if(xInput < 0 )
        {
            sprite.flipX = true;
        }
        else if (xInput > 0 )
        {
            sprite.flipX = false;
        }
    }



    private void FixedUpdate()
    {
        //rb.velocity = Vector2.right * xInput * speed;
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y); // Assign a new value to rb.velocity and keeping the current vertical velocity
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();

            if(score % 3 == 0 )
            {
                //Restart();
                Invoke("Restart", 2f); // Invoke calls a function after a certain amount of time
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("w");
    }
}