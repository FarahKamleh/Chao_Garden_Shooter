using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* note: referenced a thread in the Unity forum to do this */

public class Float : MonoBehaviour
{
    // set the speed
    float speed = 1f;

    // determine how high the object goes
    float height = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // maintain original position
        Vector3 pos = transform.position;

        // calculate new y
        float newY = Mathf.Sin(Time.time * speed);

        // change the position with the newly calculated y
        transform.position = new Vector3(pos.x, newY, pos.z) * height;
    }
}
