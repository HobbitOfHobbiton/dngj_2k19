using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcScript : MonoBehaviour
{
    [SerializeField]
    private float attackDistance = 5f;
    [SerializeField]
    private float attackInterval = 2f;
    private float attackTimeStamp;

    private Transform prey;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        prey = GameObject.Find("Frodo").transform;
        rb = GetComponent<Rigidbody2D>();
        attackTimeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (prey != null)
        {
            FollowPrey();
        }
    }

    void AssignPrey(Transform soonToBePrey)
    {
        prey = soonToBePrey;
    }

    void FollowPrey()
    {
        if (Vector2.Distance(transform.position, prey.position) > attackDistance)
        {
            rb.velocity = new Vector2(prey.position.x - transform.position.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            AttackPrey();
        }
    }

    void AttackPrey()
    {
        if (Time.time - attackTimeStamp >= attackInterval)
        {
            attackTimeStamp = Time.time;
            //attack
        }
    }
}
