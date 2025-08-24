using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercont4 : MonoBehaviour
{

    public float moveSpeed;
    float xInput, yInput;

    Vector2 targetPos;

    Rigidbody2D rb;

    SpriteRenderer sp;

    public float jumpForce;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;

    bool canDoubleJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Gotten access to the rigid body associated with the player using the rb variable
        sp = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 10f; // z value has to be greater than one so that z value forward from camera position so it can be seen

        if(Input.GetMouseButtonDown(0))
        {
            targetPos = mousePos;
        }

        //transform.position = mousePos; // Transforms the position (setting the position of the object) to mouse pos

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if(canDoubleJump)
            {
                jumpForce = jumpForce / 1.5f;
                Jump();
                canDoubleJump = false;
                jumpForce = jumpForce * 1.5f;
            }
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal"); // For our keyboard the horizontal axis are the left and right arrow keys
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0); // Accepts a vector 3 value xyz

        //ClickToMove();

        PlatformerMove();
        FlipPlayer();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer); // Position, Radius, Layer mask (which layers we want to check if its ground)
        // Creating a small circle at position of groundCheck, and checking if it overlaps or collides with any object in groundlayer returns true, else false
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void ClickToMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed); // Initial position, final position, rate of movement
    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y); // right will work as left aswell as if it is negative left means negative velocity

        // y axis velocity kept the same
        // x axis already adding the speed
    }

    void FlipPlayer()
    {
        if(rb.velocity.x < -0.1f)
        {
            sp.flipX = true;
        }
        else if(rb.velocity.x > 0.1f)
        {
            sp.flipX = false;
        }
    }
}