using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetHealth : MonoBehaviour {

    public string targetTag;
    Resource target;
    Text text;
	// Use this for initialization
	void Start () {
        target = GameObject.Find(targetTag).GetComponent<Resource>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = ((int)(target.points * 100)).ToString() + "%";
	}
}
