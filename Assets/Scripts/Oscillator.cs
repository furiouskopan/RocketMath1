using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPoint;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 1f;
    void Start()
    {
        startingPoint = transform.position;
    }
    void Update()
    {
        float cycles = Time.time * period;

        const float tau = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSineWave + 1f)/2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPoint + offset;
    }
}
