using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandFollowTarget : MonoBehaviour {


    new protected Rigidbody rigidbody;

    public float force = 10;
    public float minDiff = 0;
    public float leadTime = 0.3f;
    public Transform target = null;
    //
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {

        Vector3 diff = target.position - transform.position + rigidbody.velocity*leadTime;
 
        if(diff.magnitude > minDiff)
        {
            rigidbody.AddForce(diff * force * Time.deltaTime, ForceMode.Impulse);
        }

    }
}
