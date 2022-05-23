using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{   
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotate = 10f;
    [SerializeField] AudioClip boost;
    [SerializeField] ParticleSystem boostParticles;
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(boost);
            }
            if(!boostParticles.isPlaying)
            {
                boostParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            boostParticles.Stop();
        }
    } 
    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(mainRotate);
        }
        else if(Input.GetKey(KeyCode.D)) 
        {
            ApplyRotation(-mainRotate);
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
