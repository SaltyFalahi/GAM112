using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bullet;
    public GameObject pistol;
    public GameObject machineGun;
    public GameObject shotgun;

    public float pistolSpeed;
    public float machineGunSpeed;
    public float shotgunSpeed;

    private Rigidbody2D rb2d;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }
    
    void Update()
    {

        ChangeWeapons();

        if (Input.GetMouseButtonDown(0) && pistol.activeSelf == true)
        {

            Shoot(pistol, pistolSpeed);

        }

        if (Input.GetMouseButtonDown(0) && machineGun.activeSelf == true)
        {

            Shoot(machineGun, machineGunSpeed);

        }

        if (Input.GetMouseButtonDown(0) && shotgun.activeSelf == true)
        {

            Shoot(shotgun, shotgunSpeed);

        }
    }

    void ChangeWeapons()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            pistol.SetActive(true);

            if (pistol.activeSelf == true)
            {
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

    void Shoot(GameObject gun, float speed)
    {

        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = new Vector2(gun.transform.position.x, gun.transform.position.y);
        Vector2 direction = point - position;
        direction.Normalize();
        GameObject projectile = (GameObject)Instantiate(bullet, position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        projectile.transform.up = direction;

    }
}
