using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionSpawner : MonoBehaviour {
    // Use this for initialization
    public Transform chest;
    float multiplier = 4.0f;
    void Start () {
		
	}   
	
	// Update is called once per frame
	void Update () {
	}
    public void Spawn(float mul)
    {

        mul = Mathf.Clamp(mul, 1.2f, 4.0f);
       GameObject newOnion = Instantiate(gameObject, transform.position, transform.rotation);
        newOnion.transform.localScale = transform.lossyScale;
        Rigidbody rb = newOnion.AddComponent<Rigidbody>();
        rb.AddForce((new Vector3(0, 1, 0) + chest.forward) * multiplier * mul, ForceMode.Impulse);
    }
}
