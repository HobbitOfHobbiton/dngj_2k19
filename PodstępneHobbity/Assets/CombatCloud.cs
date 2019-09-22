using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCloud : MonoBehaviour
{
    [SerializeField]
    private float timeToLive = 1f;

    private float bornTimeStamp;

    private SpriteRenderer rn;

    // Start is called before the first frame update
    void Start()
    {
        bornTimeStamp = Time.time;
        rn = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rn.enabled && Time.time - bornTimeStamp >= timeToLive)
        {
            rn.enabled = false;
        }
    }

    public void Show()
    {
        float randomXPosMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x;
        float randomXPosMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x;
        float randomYPosMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).y;
        float randomYPosMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1)).y;

        float randomXPos = Random.Range(randomXPosMin, randomXPosMax);
        float randomYPos = Random.Range(randomYPosMin, randomYPosMax);
        transform.position = new Vector3(randomXPos, randomYPos, transform.position.z);
        rn.enabled = true;
        bornTimeStamp = Time.time;
    }
}
