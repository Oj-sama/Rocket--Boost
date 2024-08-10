using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float power = 1000 ;
    [SerializeField] float rotation = 1000 ;
    [SerializeField] AudioClip Engine ;
    [SerializeField] ParticleSystem push ; 
    
    [SerializeField] ParticleSystem left ; 
    [SerializeField] ParticleSystem right ;
    Rigidbody rb ;
    AudioSource audioSource ;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
        
    }
    void Update()
    {   
        Thrust();
        Rotate();
    }   
    void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }
    }

    

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * power * Time.deltaTime);
        if (!push.isPlaying)
        {
            push.Play();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(Engine);

        }
    }
    private void StopThrusting()
    {
        audioSource.Stop();
        push.Stop();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RightThrusting();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            LeftThrusting();
        }
        else
        StopRotation();
    }

    private void LeftThrusting()
    {
        RotationMove(-rotation);
        if (!left.isPlaying)
            left.Play();
    }

    private void RightThrusting()
    {
        RotationMove(rotation);
        if (!right.isPlaying)
            right.Play();
    }
    private void StopRotation()
    {
        left.Stop();
        right.Stop();
    }

    private void RotationMove(float m)
    {
        transform.Rotate(-Vector3.forward * m * Time.deltaTime);
    }
}