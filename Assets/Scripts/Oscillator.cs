using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 mouvementFactor;
    float mouvementVector;
    [SerializeField] float period ;
    void Start()
    {
        startingPos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        const float tau = MathF.PI * 2 ; //cost value of 6.283 
       
        float cycle = Time.time / period ; // a scalling amount of oscillation happening "a sin cycle " 
        float rawSinWave = MathF.Sin(cycle*tau);// value goes from -1 to 1
        
        mouvementVector=(rawSinWave+1)/2f;// recalculating the value so that it'll be 0 to 2 the diving by 2 so it goes to 0 to 1
        Vector3 offset = mouvementVector * mouvementFactor ;
        transform.position= startingPos + offset;
    }
}
