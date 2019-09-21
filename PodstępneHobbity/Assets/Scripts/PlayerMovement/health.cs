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
        pgx_CameraShaker.Instance.Shake(10);
        hp -= power;
        barOfHp.SetHp(hp, MaxHp);
        if (hp <= 0)
            Death();
    }

    public void damageOrc(int power)
    {
        hp -= power;
        barOfHp.SetHp(hp, MaxHp);
        if (hp <= 0)
            DeathOrc();
    }

    void Death()
    {
        CameraController.Instance.RemoveTarget(transform);
        Destroy(gameObject);
    }

    void DeathOrc()
    {
        Destroy(gameObject);
    }
}
