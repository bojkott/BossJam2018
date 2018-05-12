using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionExplosion : MonoBehaviour {

    public GameObject explosionObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject g = Instantiate(explosionObject, transform.position, Quaternion.identity);
        Destroy(g, 1.0f);
        Destroy(gameObject);
    }
}
