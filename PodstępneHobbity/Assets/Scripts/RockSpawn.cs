using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    [SerializeField]
    Transform[] Edges;
    [SerializeField]
    GameObject Rock;
    [SerializeField]
    float MaxDely = 3, MinDely = 1;

    float time = 0;
    float NextDely;

    void Start()
    {
        NextDely = MaxDely;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > NextDely)
        {
            Spawn();
            NextDely = Random.value * (MaxDely - MinDely) + MinDely;
            time = 0;
        }
    }

    void Spawn()
    {
        GameObject NewRock = Instantiate(Rock, gameObject.transform);
        float XPozytion = Random.value * (Edges[1].position.x - Edges[0].position.x) + Edges[0].position.x;
        float YPozytion = Random.value * (Edges[1].position.y - Edges[0].position.y) + Edges[0].position.y;
        NewRock.transform.position = new Vector2(XPozytion, YPozytion);
    }

}
