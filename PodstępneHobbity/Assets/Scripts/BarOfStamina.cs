using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarOfStamina : MonoBehaviour
{
    [SerializeField]
    Transform Yelow;

    float StartScale, EdgeOfBar;

    void Start()
    {
        StartScale = Yelow.localScale.x;
        EdgeOfBar = StartScale / (-200);
    }

    public void SetHp(float Stamina, float MaxStamina)
    {
        Yelow.localScale = new Vector2(StartScale * (Stamina / MaxStamina), Yelow.localScale.y);
        Yelow.localPosition = new Vector3(EdgeOfBar * ((MaxStamina - Stamina) / MaxStamina), Yelow.localPosition.y, -1);
    }
}
