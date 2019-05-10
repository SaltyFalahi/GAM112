using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs : MonoBehaviour
{

    public int drug;

    public bool withdrawl;
    public bool special;
    public bool drugged;
    public bool hit;

    private float targetTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

        drug = 1;
        withdrawl = false;
        special = false;
        drugged = false;
        hit = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q) && drug != 0 && !drugged)
        {

            withdrawl = false;

            switch (drug)
            {
                case 1:

                    gameObject.GetComponent<PlayerController>().Health += 1;
                    gameObject.GetComponent<PlayerController>().MaxSpeed = 10;
                    gameObject.GetComponent<PlayerController>().JumpSpeed = 5;
                    special = true;
                    drugged = true;
                    drug = 2;
                    targetTime = 10.0f;
                    
                    break;

                case 2:

                    gameObject.GetComponent<PlayerController>().Health += 1;
                    gameObject.GetComponent<PlayerController>().MaxSpeed = 15;
                    gameObject.GetComponent<PlayerController>().JumpSpeed = 5;
                    special = true;
                    drugged = true;
                    drug = 3;
                    targetTime = 10.0f;
                    
                    break;

                case 3:

                    gameObject.GetComponent<PlayerController>().Health += 1;
                    gameObject.GetComponent<PlayerController>().MaxSpeed = 20;
                    gameObject.GetComponent<PlayerController>().JumpSpeed = 5;
                    special = true;
                    drugged = true;
                    drug = 0;
                    targetTime = 15.0f;

                    break;
            }

        }

        if (drugged)
        {

            targetTime -= Time.deltaTime;

        }

        if (targetTime <= 0.0f || hit)
        {

            withdrawl = true;
            drugged = false;

        }

        if (withdrawl)
        {

            gameObject.GetComponent<PlayerController>().Health = 1;
            gameObject.GetComponent<PlayerController>().MaxSpeed = 5;
            gameObject.GetComponent<PlayerController>().JumpSpeed = 2;
            special = false;

        }

        if (drug == 0 && withdrawl)
        {

            gameObject.GetComponent<PlayerController>().Health = 0;

        }

    }
}
