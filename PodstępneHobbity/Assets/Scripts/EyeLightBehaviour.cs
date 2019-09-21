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

    // Start is called before the first frame update
    void Start()
    {
        delayTime = Random.Range(1, 10);
        finishedTimeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && Time.time >= finishedTimeStamp + delayTime )
        {
            GoToStartPos();
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x - cameraTransform.position.x >= distanceFromCamera)
            {
                isMoving = false;
                delayTime = Random.Range(1, 10);
                finishedTimeStamp = Time.time;
            }
        }
    }

    void GoToStartPos()
    {
        Vector3 leftEdgePos = Camera.main.ScreenToViewportPoint(new Vector3(0, Camera.main.pixelHeight, 0));
        Debug.Log(leftEdgePos);
        transform.position = new Vector3(leftEdgePos.x, transform.position.y, transform.position.z);
    }
}
