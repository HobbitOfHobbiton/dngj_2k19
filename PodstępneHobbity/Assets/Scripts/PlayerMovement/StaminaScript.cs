using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaScript : MonoBehaviour
{
    [SerializeField]
    int Stamina = 100;
    [SerializeField]
    BarOfStamina barOfStamina;

    bool OnGand = false;
    int MaxStamina;

    void Start()
    {
        MaxStamina = Stamina;
    }

    public int GetStamina ()
    {
        return Stamina;
    }

    public void LoseStamina(int HowMany)
    {
        Stamina -= HowMany;
        if (Stamina > MaxStamina)
            Stamina = MaxStamina;
        barOfStamina.SetStamina(Stamina,MaxStamina);
        if (Stamina <= 0)
            EndOfStamina();
        else
        {
            if (OnGand)
            {
                GetUp()
            }
        }
    }

    void GetUp()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.position = transform.position + Vector3.up;
        GetComponent<PlayerControlls>().enabled = true;
    }

    void EndOfStamina()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
        barOfStamina.SetStamina(0, MaxStamina);
        GetComponent<PlayerControlls>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
