using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]
    int hp = 100 ;
    [SerializeField]
    BarOfHp barOfHp;
    [SerializeField]
    private CombatCloud[] combatCloudsToStatify;
    [SerializeField]
    private SpriteRenderer[] combatCloudRensToStatify;

    private static CombatCloud[] combatClouds;
    private static SpriteRenderer[] combatCloudRens;

    int MaxHp;

    void Start()
    {
        MaxHp = hp;

        if (combatCloudsToStatify != null)
        {
            combatClouds = combatCloudsToStatify;
        }

        if (combatCloudRensToStatify != null)
        {
            combatCloudRens = combatCloudRensToStatify;
        }
    }

    public void demage(int power)
    {
        pgx_CameraShaker.Instance.Shake(10);
        hp -= power;
        barOfHp.SetHp(hp, MaxHp);
        if (hp <= 0)
            Death();
        
        ShowCombatCloud();
    }

    public void damageOrc(int power)
    {
        hp -= power;
        barOfHp.SetHp(hp, MaxHp);
        if (hp <= 0)
            DeathOrc();

        ShowCombatCloud();
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

    void ShowCombatCloud()
    {
        int randomCloudIndex = Random.Range(0, combatClouds.Length);
        if (!combatCloudRens[randomCloudIndex].enabled)
        {
            combatClouds[randomCloudIndex].Show();
        }
        else
        {
            foreach(SpriteRenderer ren in combatCloudRens)
            {
                int unusedIndex = 0;
                if (!ren.enabled)
                {
                    combatClouds[unusedIndex].Show();
                    break;
                }
                unusedIndex++;
            }
        }
    }
}
