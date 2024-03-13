using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    // speed of the floating
    float speed = 1.5f;

    // how high and low the object floats
    float height = 0.2f;

    // vector for original position
    Vector3 pos;

    private void Start()
    {
        // maintain/begin with original position
        pos = transform.position;
    }

    void Update()
    {
        // calculate new y position
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;

        // set new position based on new y
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}