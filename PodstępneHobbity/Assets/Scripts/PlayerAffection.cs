using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAffection : MonoBehaviour
{
    //private SpriteRenderer rn;

    private bool isProtected = false;
    private bool isUnderLight = false;
    private EyeLightBehaviour Sauron;

    void Start()
    {
        //rn = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SauronLight" && this.name == "Frodo")
        {
            isUnderLight = true;
            Sauron = col.gameObject.GetComponent<EyeLightBehaviour>();

            if (!isProtected)
            {
                GetAffectedByEyeLight();
            }
        }

        if (col.gameObject.tag == "ProtectingBoulder" && this.name == "Frodo")
        {
            isProtected = true;
            //rn.color = new Color(1f, 1f, 1f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "SauronLight" && this.name == "Frodo")
        {
            //rn.color = new Color(1f, 1f, 1f);
            isUnderLight = false;
        }

        if (col.gameObject.tag == "ProtectingBoulder" && this.name == "Frodo")
        {
            isProtected = false;

            if (isUnderLight)
            {
                GetAffectedByEyeLight();
            }
        }
    }

    void GetAffectedByEyeLight()
    {
        //rn.color = new Color(100, 0, 0);
        GetComponent<StaminaScript>().LoseStamina(1000);
        Sauron.SauronStop();
    }
}
