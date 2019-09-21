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
    bool TookFrodo = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TookFrodo == false)
        {
            if (Vector3.Distance(transform.position, Frodo.position) < RangeToHelp)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Frodo.GetComponent<FrodoIsCaring>().enabled = true;
                    Frodo.GetComponent<FrodoIsCaring>().StartCaring(transform);
                    TookFrodo = true;
                }
            }
        }
        else
        {
            Debug.Log("else");
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("GetKey");
                Frodo.GetComponent<FrodoIsCaring>().StopCaring();
                Frodo.GetComponent<FrodoIsCaring>().enabled = false;
                TookFrodo = false;
            }
        }
    }
}
