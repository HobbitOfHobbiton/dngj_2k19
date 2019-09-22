using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField]
    Transform Owner;

    SpriteRenderer sr;
    BoxCollider2D col;
    bool OnGround = false;


    void Start()
    {
        Owner = GameObject.Find("Frodo").transform;
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Owner == null)
        {
            sr.enabled = true;
            OnGround = true;
        }
        else
        {
            transform.position = Owner.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && OnGround)
        {
            Owner = collision.transform;
            sr.enabled = false;
            OnGround = false;
        }
    }
}
