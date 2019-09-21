using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    int Demage=75;
    [SerializeField]
    float TimeToDestroy = 5;

    void Update()
    {
        TimeToDestroy -= Time.deltaTime;
        if (TimeToDestroy < 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<health>().demage(Demage);
    }
}
