using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrodoIsCaring : MonoBehaviour
{
    Transform SamTransform;

    public void StartCaring(Transform Sam)
    {
        SamTransform = Sam;
        transform.localEulerAngles = new Vector3(0, 0, 90);
    }

    void Update()
    {
        transform.position = SamTransform.position + new Vector3(1,2,0);
    }

    public void StopCaring()
    {
        if (GetComponent<StaminaScript>().GetStamina()>0)
        {
            transform.localEulerAngles = Vector3.zero;
            GetComponent<PlayerControlls>().enabled = true;
        }
    }
}
