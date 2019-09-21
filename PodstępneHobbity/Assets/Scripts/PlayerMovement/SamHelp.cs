using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamHelp : MonoBehaviour
{
    [SerializeField]
    Transform Frodo;
    [SerializeField]
    float RangeToHelp = 3f;

    StaminaScript FrodoStamina;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,Frodo.position)<RangeToHelp)
        {
            Debug.Log("blisko");
        }
    }
}
