using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamFeedingController : MonoBehaviour
{
    [SerializeField]
    private int staminaFeed = 40;

    private PlayerAffection affection;
    private bool canFeed = false;
    private StaminaScript frodoStamina;

    // Start is called before the first frame update
    void Start()
    {
        affection = transform.parent.GetComponent<PlayerAffection>();
        frodoStamina = GameObject.Find("Frodo").GetComponent<StaminaScript>();
    }

    void Update()
    {
        if (canFeed && Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("FEEDING");
            affection.Food -= 1;
            frodoStamina.LoseStamina(-staminaFeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Frodo")
        {
            Debug.Log("CAN FEED FRODO");
            canFeed = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Frodo")
        {
            Debug.Log("CANT FEED FRODO");
            canFeed = false;
        }
    }
}
