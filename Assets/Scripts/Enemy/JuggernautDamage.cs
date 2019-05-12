using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautDamage : MonoBehaviour
{

    public float multiplier;

    public Vector2 force;

    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            force = this.GetComponent<Rigidbody2D>().velocity * multiplier;
            player.GetComponent<Rigidbody2D>().AddForce(force);
            this.GetComponent<Rigidbody2D>().AddForce(-force);
            player.GetComponent<PlayerController>().Health -= 1;

        }

    }
}
