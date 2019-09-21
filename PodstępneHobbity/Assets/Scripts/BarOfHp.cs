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
        EdgeOfBar = (-200) / StartScale;
    }

    public void SetHp(int Hp, int MaxHp)
    {
        Red.localScale = new Vector2(StartScale * (Hp / MaxHp), Red.localScale.y);
        Red.localPosition = new Vector2(EdgeOfBar * ((MaxHp - Hp) / MaxHp), Red.localPosition.y);
    }
}
