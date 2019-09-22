using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAffection : MonoBehaviour
{
    //private SpriteRenderer rn;

    [SerializeField]
    private bool isProtected = false;
    private bool isUnderLight = false;
    private EyeLightBehaviour Sauron;
    private static SamFeedingController samFeedingController;
    [SerializeField]
    private SpriteRenderer[] Body;

    void Start()
    {
        //rn = GetComponent<SpriteRenderer>();
        samFeedingController = GameObject.Find("Sam").GetComponentInChildren<SamFeedingController>();
        Body = transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>();
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
            ChangeColour(Color.gray);
            //rn.color = new Color(1f, 1f, 1f);

        }

        if (col.gameObject.tag == "Food" && this.name == "Sam")
        {
            samFeedingController.Food += 1;
            Destroy(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "SauronLight" && this.name == "Frodo")
        {
            //rn.color = new Color(1f, 1f, 1f);
            isUnderLight = false;
            Sauron.FrodoEscape();
        }

        if (col.gameObject.tag == "ProtectingBoulder" && this.name == "Frodo")
        {
            ChangeColour(new Color(255, 255, 255));
            isProtected = false;

            if (isUnderLight)
            {
                GetAffectedByEyeLight();
            }
        }
    }

    void ChangeColour (Color color)
    {
        for (int i=0; i< Body.Length; i++)
        {
            Body[i].color = color;
        }
    }

    void GetAffectedByEyeLight()
    {
        //rn.color = new Color(100, 0, 0);
        GetComponent<StaminaScript>().LoseStamina(1000);
        Sauron.SauronStop();
    }
}
