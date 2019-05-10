using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MaxSpeed = 5;
    public float Acceleration = 35;
    public float JumpSpeed = 3;
    public float JumpTime;
    public float Health = 1;
    private Vector3 rollDirection;
    private Vector2 mousePos;   

    public bool isGrounded;

    Rigidbody2D rb2d;

    float jumpTimeCounter;

    bool isJumping = false;

	// Use this for initialization
	void Start ()
    {

        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {

            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if(horizontal < 0)
        {

            transform.eulerAngles = new Vector3(0, 0, 0);

        }

        if (horizontal < -0.1f)
        {

            if (rb2d.velocity.x > -this.MaxSpeed)
            {

                rb2d.AddForce(new Vector2(-this.Acceleration, rb2d.velocity.y));

            }
            else
            {

                rb2d.velocity = new Vector2(-this.MaxSpeed, rb2d.velocity.y);

            }

        }
        else if (horizontal > 0.1f)
        {

            if (rb2d.velocity.x < this.MaxSpeed)
            {

                rb2d.AddForce(new Vector2(this.Acceleration, rb2d.velocity.y));

            }
            else
            {

                rb2d.velocity = new Vector2(this.MaxSpeed, rb2d.velocity.y);

            }

        }
        
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            isJumping = true;
            jumpTimeCounter = JumpTime;
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpSpeed);

        }
        
        if(Input.GetKey(KeyCode.Space) && isJumping)
        {

            if(jumpTimeCounter > 0)
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, JumpSpeed);
                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {

                isJumping = false;

            }

        }
        DodgeRoll();
        Slide();

        if (Input.GetKeyUp(KeyCode.Space))
        {

            isJumping = false;

        }   
    }

    private void DodgeRoll()
    {
        rollDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        if (Input.GetKeyDown(KeyCode.C))
        {
            MaxSpeed = 50f;
            transform.position += rollDirection * MaxSpeed * Time.deltaTime;
        }
    }

    private void Slide()
    {
        rollDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        if (Input.GetKeyDown(KeyCode.X))
        {
            MaxSpeed = 50f;
            transform.position += rollDirection * MaxSpeed * Time.deltaTime;
        }
    }

}
