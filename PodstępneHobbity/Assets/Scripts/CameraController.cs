using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private List<Transform> _targetsToFollow;
    [SerializeField, Range(1.0f, 20.0f)] private float _followSpeed = 5.0f;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);

    void Start()
    {
        if (_targetsToFollow.Count == 0)
        {
            PlayerControlls [] players = FindObjectsOfType<PlayerControlls>();
            _targetsToFollow = new List<Transform>();

            foreach(var pl in players)
            {
                _targetsToFollow.Add(pl.transform);
            }
        }
            

        Instance = this;
    }

    void Update()
    {
        Vector3 targetPos = AverageVector();
        transform.position = Vector3.Lerp(transform.position, targetPos + _offset, Time.unscaledDeltaTime * _followSpeed);
    }

    Vector3 AverageVector()
    {
        float x = 0, y = 0, z = 0;

        for(int i = 0; i < _targetsToFollow.Count; i++)
        {
            x += _targetsToFollow[i].position.x;
            y += _targetsToFollow[i].position.y;
            z += _targetsToFollow[i].position.z;
        }

        return new Vector3(x, y, z) / _targetsToFollow.Count;
    }

    public void AddTarget(Transform target)
    {
        _targetsToFollow.Add(target);
    }

    public void RemoveTarget(Transform target)
    {
        _targetsToFollow.Remove(target);

        if (_targetsToFollow.Count == 0) Destroy(this);
    }
}
