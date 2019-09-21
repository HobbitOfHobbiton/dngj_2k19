using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaScript : MonoBehaviour
{
    [SerializeField]
    int Stamina = 100;
    [SerializeField]
    BarOfHp barOfStamina;

    int MaxStamina;

    void Start()
    {
        MaxStamina = Stamina;
    }

    void Update()
    {
        
    }

    public void LoseStamina(int HowMany)
    {
        Stamina -= HowMany;
        if (Stamina <= 0)
            EndOfStamina();
    }

    void EndOfStamina()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
    }
}
