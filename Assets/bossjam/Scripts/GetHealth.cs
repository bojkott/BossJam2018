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
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Resource>();
        text.text = ((int)(target.points * 100)).ToString() + "%";
	}
}
