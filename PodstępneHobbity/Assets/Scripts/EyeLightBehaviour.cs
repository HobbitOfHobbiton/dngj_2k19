using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLightBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float distanceFromCamera = 100f;

    private float delayTime = 0f;
    private float finishedTimeStamp;

    private bool isMoving = false;

    private float leftEdgePos;
    private float rightEdgePos;

    private SpriteRenderer rn;

    // Start is called before the first frame update
    void Start()
    {
        rn = GetComponent<SpriteRenderer>();
        delayTime = Random.Range(1, 10);
        finishedTimeStamp = Time.time;
        leftEdgePos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x-5f;
        rightEdgePos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x+5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && Time.time >= finishedTimeStamp + delayTime )
        {
            GoToStartPos();
            rn.enabled = true;
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= rightEdgePos)
            {
                isMoving = false;
                rn.enabled = false;
                delayTime = Random.Range(1, 10);
                finishedTimeStamp = Time.time;
            }
        }
    }

    void GoToStartPos()
    {
        transform.position = new Vector3(leftEdgePos, transform.position.y, transform.position.z);
    }
}
