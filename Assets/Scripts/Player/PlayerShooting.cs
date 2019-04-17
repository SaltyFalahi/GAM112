using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 mousePos;
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
            Vector2 point = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 position = new Vector2(gun.transform.position.x, gun.transform.position.y);
            Vector2 direction = point - position;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bullet, point, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            Debug.Log(point);
        }
    }

    /*public void PlayerShootPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics2D.Raycast(ray, out hit, 1000))
        {
            mousePos = hit.point;
            Debug.Log("LMAO");
        }
    }*/
}
