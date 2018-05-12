using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionSpawner : MonoBehaviour {
    // Use this for initialization
    float multiplier = 2.0f;
    void Start () {
		
	}   
	
	// Update is called once per frame
	void Update () {
	}

    public void Spawn()
    {
       GameObject newOnion = Instantiate(gameObject, transform.position, transform.rotation);
        newOnion.transform.localScale = transform.lossyScale;
        Rigidbody rb = newOnion.AddComponent<Rigidbody>();
        rb.AddForce((new Vector3(0, 5, 0) + GetComponentInParent<Rigidbody>().velocity) * multiplier, ForceMode.Impulse);
    }
}
