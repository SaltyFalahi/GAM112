using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float offset = 10;
    public GameObject player;

    void Start()
    {
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= offset)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
          
=======
         
>>>>>>> Drugs
        if (collision.gameObject.tag == "Enemy")
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject); 
        }
    }
}
