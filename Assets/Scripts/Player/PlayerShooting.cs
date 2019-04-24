using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Rigidbody2D rb2d;
    public GameObject bullet;
    public GameObject pistol;
    public GameObject machineGun;
    public GameObject shotgun;
    public float pistolSpeed;
    public float machineGunSpeed;
    public float shotgunSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pistolSpeed = 8;
        machineGunSpeed = 10;
        shotgunSpeed = 6;
    }
    

    void Update()
    {

        ChangeWeapons();

        
        if (Input.GetMouseButtonDown(0) && pistol.activeSelf == true)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pistolPosition = new Vector2(pistol.transform.position.x, pistol.transform.position.y);
            Vector2 direction = point - pistolPosition;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bullet, pistolPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * pistolSpeed;
            projectile.transform.up = direction;
            Debug.Log(point);
            Debug.Log(pistolPosition);
        }


        if (Input.GetMouseButtonDown(0) && machineGun.activeSelf == true)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 machineGunPosition = new Vector2(machineGun.transform.position.x, machineGun.transform.position.y);
            Vector2 direction = point - machineGunPosition;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bullet, machineGunPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * machineGunSpeed;
            projectile.transform.up = direction;
        }

        if (Input.GetMouseButtonDown(0) && shotgun.activeSelf == true)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shotgunPosition = new Vector2(shotgun.transform.position.x, shotgun.transform.position.y);
            Vector2 direction = point - shotgunPosition;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(bullet, shotgunPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shotgunSpeed;
            projectile.transform.up = direction;
        }
    }

    void ChangeWeapons()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            pistol.SetActive(true);
            if (pistol.activeSelf == true)
            {
                Debug.Log("first");
                machineGun.SetActive(false);
                shotgun.SetActive(false);
            }
        }
        

        if (Input.GetKey(KeyCode.Keypad2))
        {
            machineGun.SetActive(true);
            if (machineGun.activeSelf == true)
            {
                pistol.SetActive(false);
                shotgun.SetActive(false);
            }
        }
        

        if (Input.GetKey(KeyCode.Keypad3))
        {
            shotgun.SetActive(true);
            if (shotgun.activeSelf == true)
            {
                pistol.SetActive(false);
                machineGun.SetActive(false);
            }
        }
    }
}
