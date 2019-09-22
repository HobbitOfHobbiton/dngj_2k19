using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaScript : MonoBehaviour
{
    [SerializeField]
    int Stamina = 100;
    [SerializeField]
    BarOfStamina barOfStamina;

    bool OnGrand = false;
    int MaxStamina;

    void Start()
    {
        MaxStamina = Stamina;
    }
/*
    private void Update()
    {
        if (OnGrand)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
*/
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
            if (OnGrand)
            {
                GetUp();
            }
        }
    }

    void GetUp()
    {
        Debug.Log("GET UP");
        transform.localEulerAngles = new Vector3(0, 0, 0);
        transform.position = transform.position + Vector3.up;
        GetComponent<PlayerControlls>().enabled = true;
        OnGrand = false;
        CameraController.Instance.AddTarget(transform);
    }

    void EndOfStamina()
    {
        OnGrand = true;
        transform.localEulerAngles = new Vector3(0, 0, 90);
        barOfStamina.SetStamina(0, MaxStamina);
        GetComponent<PlayerControlls>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //GetComponent<Rigidbody2D>().simulated = false;
        Stamina = 0;
        CameraController.Instance.RemoveTarget(transform);
    }
}
