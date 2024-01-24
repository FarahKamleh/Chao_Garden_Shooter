using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmochaoCollision : MonoBehaviour
{
    // Omochao sound
    public AudioSource hurts;
    public AudioSource bully;
    public AudioSource why;

    // collision counter
    int colCount = 0;

    // when Omochao is hit
    private void OnCollisionEnter(Collision collision)
    {
        // add to collision counter
        colCount++;

        // if first hit, play hurts
        if (colCount == 1)
        {
            hurts.Play();
        }

        // if second, play why
        else if (colCount == 2)
        {
            why.Play();
        }

        // if third, play bully
        else if (colCount == 3)
        {
            bully.Play();

            // reset counter
            colCount = 0;
        }

    }
}
