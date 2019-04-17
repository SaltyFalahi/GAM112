using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject bullet;
    public GameObject gun;
    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 5;
    }
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 position = new Vector2(gun.transform.position.x, gun.transform.position.y);
            Vector2 direction = point - position;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            projectile.transform.up = direction;
            Debug.Log(point);
            Debug.Log(position);
        }
    }
}
