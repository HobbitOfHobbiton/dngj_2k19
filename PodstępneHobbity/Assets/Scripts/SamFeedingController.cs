using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamFeedingController : MonoBehaviour
{
    [SerializeField]
    private int staminaFeed = 40;

    private PlayerAffection affection;
    private bool canFeed = false;

    [SerializeField]
    private Text foodText;

    private int food;

    private static StaminaScript frodoStamina;

    [SerializeField]
    private int startFood = 4;

    public int Food
    {
        get
        {
            return food;
        }

        set
        {
            if ( value >= 0)
            {
                if (value < food)
                {
                    frodoStamina.LoseStamina(-staminaFeed);
                }

                food = value;
            }
            foodText.text = food.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        affection = transform.parent.GetComponent<PlayerAffection>();
        Food = startFood;
        frodoStamina = GameObject.Find("Frodo").GetComponent<StaminaScript>();
    }

    void Update()
    {
        if (canFeed && Input.GetKeyDown(KeyCode.RightShift))
        {
            Food -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Frodo")
        {
            canFeed = true;
            Debug.Log("CAN FEED");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Frodo")
        {
            canFeed = false;
        }
    }
}
