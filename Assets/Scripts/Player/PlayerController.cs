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

    public bool isGrounded;

    private Rigidbody2D rb2d;

    private float jumpTimeCounter;

    private bool isJumping = false;

    private Vector3 rollDirection;

    private Vector2 mousePos;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {

            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (horizontal < 0)
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

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {

            isJumping = true;
            jumpTimeCounter = JumpTime;
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpSpeed);

        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {

            if (jumpTimeCounter > 0)
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, JumpSpeed);
                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {

                isJumping = false;

            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            isJumping = false;

        }

        if (Health == 0)
        {

            //Gameover screen

        }

        DodgeRoll();
        Slide();

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
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {

            isGrounded = true;

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {

            isGrounded = false;

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("BulletE"))
        {

            Health -= 1;

        }

    }
}
