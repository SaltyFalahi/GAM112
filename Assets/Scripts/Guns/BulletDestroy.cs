using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float lifetime;

    public bool isPlayer;
    public bool isEnemy;

    public GameObject shooter;

    void Start()
    {
    }

    void Update()
    {

        Destroy(gameObject, lifetime);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
             
        if (collision.gameObject.tag == "Enemy" && isPlayer || collision.gameObject.tag == "Player" && isEnemy)
        {
            
            Destroy(gameObject); 

        }

    }

}
