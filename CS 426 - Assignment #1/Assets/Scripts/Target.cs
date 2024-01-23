//lets add some target
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Score scoreManager;
    public AudioSource audioSource;

    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        //on collision adding point to the score
        scoreManager.AddPoint();

        // printing if collision is detected on the console
        Debug.Log("Collision Detected");

        // EDIT: make chao sound
        audioSource.Play();

        //after collision is detected destroy the gameobject
        Destroy(gameObject);
    }
}