using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaPhoneSpawner : MonoBehaviour {

    public Transform spawnPoint;
    public GameObject blast;
	// Use this for initialization
	void Start () {
		
	}
	
    public void Spawn()
    {
        Instantiate(blast, spawnPoint.position, spawnPoint.rotation);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
