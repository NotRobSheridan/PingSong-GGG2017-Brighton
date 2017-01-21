using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalWallJuice : MonoBehaviour {

    public float speed = 1.0f;
    public float intensity = 1.0f;
    Vector2 initialPos;

    void start()
    {
        initialPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ball")
        {
            Debug.Log("Hit Vertical Wall");
            Vector2 juicePos = new Vector2(transform.position.x = Mathf.Sin(Time.time * speed), transform.position.y);

        }
    }
}
