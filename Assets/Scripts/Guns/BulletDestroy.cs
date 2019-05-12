using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float offset = 10;
    public GameObject shooter;

    void Start()
    {
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, shooter.transform.position) >= offset)
        {

            Destroy(gameObject);

        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
             
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject); 

        }

    }

}
