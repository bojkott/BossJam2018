﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countdownForce : MonoBehaviour {

    public float force = 10.0f;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
