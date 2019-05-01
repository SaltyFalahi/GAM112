using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity;

    Rigidbody2D rb2d;

	void Awake ()
    {

        rb2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if (rb2d.velocity.y < 0)
        {

            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if(rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {

            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }

        if (Input.GetButtonDown("Jump"))
        {
            
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;

        }

	}
}
