using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterFloat : MonoBehaviour
{
    // speed of the floating
    float speed = 2f;

    // how high and low the chao floats
    float height = 0.1f;

    void Update()
    {
        // maintain original position
        Vector3 pos = transform.position;

        // calculate y position
        float newY = Mathf.Sin(Time.time * speed);

        // set new position based on new y
        transform.position = new Vector3(pos.x, newY * height, pos.z);
    }
}
