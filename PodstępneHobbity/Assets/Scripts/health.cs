using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]
    int hp = 100;
    
    public void demage(int power)
    {
        hp -= power;
        if (hp <= 0)
            Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
