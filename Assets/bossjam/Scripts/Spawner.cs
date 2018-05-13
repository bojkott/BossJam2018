using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private GameObject target;
    public GameObject prefab;
    public int controllerId = 0;
    // Use this for initialization
    void Start () {
        target = Instantiate(prefab, transform.position, prefab.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Back_" + (controllerId+1).ToString()))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject g = Instantiate(prefab, transform.position, transform.rotation);
        g.GetComponent<Resource>().points = target.GetComponent<Resource>().points;
        Destroy(target);
        target = g;
        
    }
}
