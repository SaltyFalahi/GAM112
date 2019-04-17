using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MaxSpeed = 10;
    public float Acceleration = 35;
    public float JumpSpeed = 8;
    public float JumpDuration;

    Rigidbody2D rb2d;

    float jmpDuration;

    bool jumpKeyDown = false;
    bool canJump = false;

	// Use this for initialization
	void Start ()
    {

        rb2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {

        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < -0.1f)
        {

            if (rb2d.velocity.x > -this.MaxSpeed)
            {

                rb2d.AddForce(new Vector2(-this.Acceleration, 0.0f));

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

                rb2d.AddForce(new Vector2(this.Acceleration, 0.0f));

            }
            else
            {

                rb2d.velocity = new Vector2(this.MaxSpeed, rb2d.velocity.y);

            }

        }

    }

    /*private bool Grounded()
    {



    }*/

}
