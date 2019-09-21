using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarOfHp : MonoBehaviour
{
    [SerializeField]
    Transform Red;

    float StartScale, EdgeOfBar;

    void Start()
    {
        StartScale = Red.localScale.x;
        EdgeOfBar = StartScale / (-200) ;
    }

    public void SetHp(float Hp, float MaxHp)
    {
        Debug.Log("StartScale = " + StartScale);
        Debug.Log("Hp = " + Hp);
        Debug.Log("MaxHp = " + MaxHp);
        Debug.Log("StartScale * (Hp / MaxHp) = " + StartScale * (Hp / MaxHp));
        Debug.Log("(Hp / MaxHp) = " + (Hp / MaxHp));

        Red.localScale = new Vector2(StartScale * (Hp / MaxHp), Red.localScale.y);
        Red.localPosition = new Vector3(EdgeOfBar * ((MaxHp - Hp) / MaxHp), Red.localPosition.y,-1);
    }
}
