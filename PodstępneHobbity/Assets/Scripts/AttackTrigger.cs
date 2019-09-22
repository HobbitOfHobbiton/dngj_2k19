using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private OrcScript orcParent;

    void Start()
    {
        orcParent = transform.parent.GetComponent<OrcScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )//&& collision.gameObject.name == "Frodo") Niech biją też Sama
        {
            orcParent.AssignPrey(collision.gameObject.transform);
        }
    }
}
