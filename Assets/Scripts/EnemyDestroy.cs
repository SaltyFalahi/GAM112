using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("shit");
        if (collision.gameObject.tag.Equals ("Bullet"))
        {
            Debug.Log("poop");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals ("Bullet"))
        {
            Debug.Log("poops");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
