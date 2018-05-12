using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class meshSaver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AssetDatabase.CreateAsset(GetComponent<MeshFilter>().mesh, gameObject.name + ".asset" );
        AssetDatabase.SaveAssets();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
