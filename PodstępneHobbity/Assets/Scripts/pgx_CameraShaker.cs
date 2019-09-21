using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pgx_CameraShaker : MonoBehaviour
{
    public static pgx_CameraShaker Instance;
    public float shakeSpeed = 10.0f;
    public float shakeDecay = 5.0f;
    //[HideInInspector]

    private float shakeAmplitude = 0.0f;
    private bool _constantShake;

    Vector2 shake;

	void Start ()
    {
        Instance = this;
    }
	
	void Update ()
    {
        if (!_constantShake)
        {
            shakeAmplitude = Mathf.SmoothStep(shakeAmplitude, 0.0f, Time.deltaTime * shakeDecay);
        }

        float bx = (Mathf.PerlinNoise(0, Time.time * shakeSpeed) - 0.5f);
        float by = (Mathf.PerlinNoise(0, (Time.time * shakeSpeed) + 100)) - 0.5f;

        bx *= shakeAmplitude;
        by *= shakeAmplitude;

        shake = new Vector2(bx, by);
        transform.localPosition = shake;
    }

    public void Shake(float amplitude)
    {
        shakeAmplitude = amplitude;
    }

    public void ConstantShakeStart(float amplitude)
    {
        shakeAmplitude = amplitude;
        _constantShake = true;
    }

    public void ConstantShakeEnd()
    {
        _constantShake = false;
    }
}
