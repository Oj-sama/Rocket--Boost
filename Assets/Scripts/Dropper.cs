using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{   
    [SerializeField] float timeNeeded;
    Rigidbody rb ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity=false;
        StartCoroutine(enableRb());
    }

   
    IEnumerator enableRb()
    {
        yield return new WaitForSeconds(timeNeeded);
        rb.useGravity=true ;
    }
}
