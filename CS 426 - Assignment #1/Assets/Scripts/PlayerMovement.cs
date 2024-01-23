// shoot
// using __ imports namespace
// Namespaces are collection of classes, data types
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehavior is the base class from which every Unity Script Derives
public class PlayerMovement : MonoBehaviour
{
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 700f;

    // EDIT: reference Sonic
    public GameObject character;

    // EDIT: for multiple animations
    private Animation anim;

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
        
        // EDIT: get the animation
        anim = character.GetComponent<Animation>();

        // EDIT: at the start, make sure animation doesnt play
        character.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
            
            // EDIT: make sure jump animation stops playing
            if (!character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("sn_ball_loop"))
            {
                // EDIT: enable animator and play the running animation
                character.GetComponent<Animator>().enabled = true;
                anim.Play("sn_run_loop");
            }

        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        // EDIT: force is now 300f
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(t.up * (force - 400f));

            // EDIT: make jump sound
            audioSource.Play();

            // EDIT: if jumping, turn on animation
            character.GetComponent<Animator>().enabled = true;
            anim.Play("sn_ball_loop");
        }

        // https://docs.unity3d.com/ScriptReference/Input.html
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 2;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 1500);
        }

    }

    // EDIT: if character lands, stop spinning animation
    private void OnCollisionEnter(Collision collision)
    {
        // EDIT: if animation already playing, then stop it
        if (character.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("sn_ball_loop"))
        {
            character.GetComponent<Animator>().enabled = false;
        }
    }
}