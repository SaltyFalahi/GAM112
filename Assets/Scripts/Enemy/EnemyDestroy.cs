using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    public GameObject player;

    private GameObject enemy;

    void Start()
    {

        enemy = this.gameObject;

    }
    
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag.Equals ("Bullet") && !player.GetComponent<Drugs>().drugged)
        {

            enemy.GetComponent<AIBasic>().health -= 1;

        }
        else if(collision.gameObject.tag.Equals("Bullet") && player.GetComponent<Drugs>().drugged)
        {

            enemy.GetComponent<AIBasic>().health -= 10;

        }

    }

}
