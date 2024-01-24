// shoot
// using __ imports namespace
// Namespaces are collection of classes, data types
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehavior is the base class from which every Unity Script Derives
public class PlayerMovement : MonoBehaviour
{
    // EDIT: speed changed to 10f
    public float speed = 10.0f;
    public float rotationSpeed = 90;

    // EDIT: force changed to 300f
    public float force = 300f;

    // EDIT: reference animator
    Animator animator;

    // EDIT: for jump sound
    public AudioSource audioSource;

    public GameObject cannon;
    public GameObject bullet;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();

        // EDIT: get the animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += this.transform.forward * speed * Time.deltaTime;

            // EDIT: start running
            animator.SetBool("isRunning", true);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

            // EDIT: run backwards
            animator.SetBool("isBackwards", true);
        }

        // EDIT: if not pressing S, then stop animation
        if (!Input.GetKey(KeyCode.S))
        {
            // EDIT: do not run backwards
            animator.SetBool("isBackwards", false);
        }

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        // EDIT: if not pressing w or s, return to idle
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", false);
        }

        // EDIT: force is now 300f
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(t.up * (300f));

            // EDIT: make jump sound
            audioSource.Play();

            // EDIT: trigger jump animation
            animator.SetBool("isJumping", true);
        }


        // https://docs.unity3d.com/ScriptReference/Input.html
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
        }

    }

    // EDIT: if collision detected, return to idle state
    private void OnCollisionEnter(Collision collision)
    {
        // EDIT: if jumping is true
        if (animator.GetBool(Animator.StringToHash("isJumping")))
        {
            // EDIT: stop jumping animation
            animator.SetBool("isJumping", false);
        }
    }
}