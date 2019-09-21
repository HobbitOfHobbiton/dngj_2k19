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
    private bool isAtacking = false;

    private float leftEdgePos;
    private float rightEdgePos;

    private SpriteRenderer rn;
    private CapsuleCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rn = GetComponent<SpriteRenderer>();
        col = GetComponent<CapsuleCollider2D>();
        delayTime = Random.Range(1, 10);
        finishedTimeStamp = Time.time;
        leftEdgePos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x-5f;
        rightEdgePos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x+5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAtacking)
        {
            
        }
        else
        {
            if (!isMoving && Time.time >= finishedTimeStamp + delayTime)
            {
                GoToStartPos();
                SetLight(true);
            }

            if (isMoving)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;

                if (transform.position.x >= rightEdgePos)
                {
                    SetLight(false);
                    delayTime = Random.Range(1, 10);
                    finishedTimeStamp = Time.time;
                }
            }
        }
    }

    public void SauronStop()
    {
        isAtacking = true;
        Debug.Log("SauronStop");
    }

    public void FrodoEscape()
    {
        isAtacking = false;
    }

    void GoToStartPos()
    {
        transform.position = new Vector3(leftEdgePos, transform.position.y, transform.position.z);
    }

    void SetLight(bool value)
    {
        isMoving = value;
        rn.enabled = value;
        col.enabled = value;
    }
}
