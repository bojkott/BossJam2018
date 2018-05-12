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

        diff.y *= -Physics.gravity.y;
        if(diff.magnitude > minDiff)
        {
            float dist = diff.magnitude;
            float pullM = Mathf.Clamp01(dist / 0.3f);
            rigidbody.AddForce(pullM * force * Time.deltaTime * diff, ForceMode.Impulse);
        }

    }
}
