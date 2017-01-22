using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWallJuice : MonoBehaviour {

    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public Transform wall;
    Vector3 initialPos;


    void Awake()
    {
        if (wall == null)
            wall = GetComponent(typeof(Transform)) as Transform;
    }

    void Start()
    {
        initialPos = transform.localPosition;
    }

   void Update()
    {
        if (shakeDuration > 0)
        {
            wall.localPosition = initialPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            wall.localPosition = initialPos;
        }
    }

    public void GetJuicy()
    {
        shakeDuration = 0.3f;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
