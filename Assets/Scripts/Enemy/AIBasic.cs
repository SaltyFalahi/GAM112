using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyStates
{

    Patrol,
    Chase,
    Attack,

}

public class AIBasic : MonoBehaviour
{
    public enemyStates currState;

    public int health;

    public float attackDistance;
    public float chaseDistance;
    public float desireDistance;
    public float escapeDistance;
    public float moveForce;
    public float speed;
    public float cooldown;

    public GameObject player;
    public GameObject bullet;

    public Transform[] patrolPoints;

    private bool shot;

    private Rigidbody2D enemyRigidB;

    private DistanceChecker distanceCheck;

    private Transform currentTarget;

    void Start()
    {

        enemyRigidB = GetComponent<Rigidbody2D>();
        distanceCheck = GameObject.FindObjectOfType<DistanceChecker>();
        cooldown = 5f;
        currentTarget = patrolPoints[0];
        SetState(enemyStates.Patrol);

    }

    void Update()
    {

        EnemyStateCase();
        EnemyMovement();

        if (health <= 0)
        {

            Destroy(this.gameObject);

        }

    }

    void EnemyStateCase()
    {

        switch (currState)
        {

            case enemyStates.Patrol:
                {

                    EnemyPatrol();
                    
                    if (distanceCheck.Distance(gameObject.transform, player.transform) <= chaseDistance)
                    {

                        SetState(enemyStates.Chase);

                    }

                }

                break;

            case enemyStates.Chase:
                {

                    EnemyChase();

                    if (distanceCheck.Distance(gameObject.transform, player.transform) >= escapeDistance)
                    {

                        SetState(enemyStates.Patrol);

                    }

                    if (distanceCheck.Distance(gameObject.transform, player.transform) <= attackDistance)
                    {

                        SetState(enemyStates.Attack);

                    }
                    
                }

                break;

            case enemyStates.Attack:
                {

                    cooldown -= Time.deltaTime;

                    if (cooldown <= 0)
                    {

                        Vector2 point = Camera.main.ScreenToWorldPoint(player.transform.position);
                        Vector2 position = new Vector2(transform.position.x, transform.position.y);
                        Vector2 direction = point - position;
                        direction.Normalize();
                        GameObject projectile = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
                        projectile.transform.up = direction;
                        cooldown = 5f;

                    }

                }

                break;

        }

    }

    void SetState(enemyStates state)
    {

        currState = state;

    }

    void EnemyPatrol()
    {

        if (distanceCheck.Distance(gameObject.transform, currentTarget) <= desireDistance)
        {

            if (currentTarget == patrolPoints[0])
            {

                currentTarget = patrolPoints[1];

            }
            else
            {

                currentTarget = patrolPoints[0];

            }

        }

    }

    void EnemyChase()
    {

        currentTarget = player.transform;

    }

    void EnemyMovement()
    {

        if (currentTarget != null)
        {

            Vector2 dir = currentTarget.position - transform.position;
            enemyRigidB.AddForce(dir.normalized * moveForce, ForceMode2D.Force);

        }

    }

}
