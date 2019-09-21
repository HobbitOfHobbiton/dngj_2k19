using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]
    int hp = 100 ;
    [SerializeField]
    BarOfHp barOfHp;

    int MaxHp;

    void Start()
    {
        MaxHp = hp;
    }

    public void demage(int power)
    {
        hp -= power;
        barOfHp.SetHp(hp, MaxHp);
        if (hp <= 0)
            Death();
    }

    void Death()
    {
        CameraController.Instance.RemoveTarget(transform);
        Destroy(gameObject);
    }
}
