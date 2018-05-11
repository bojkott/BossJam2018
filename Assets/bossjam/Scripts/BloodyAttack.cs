using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyAttack : MonoBehaviour {

    Animation attack;
    public AnimationClip clip;
	// Use this for initialization
	void Start () {
        attack = GetComponent<Animation>();
        attack.clip = clip;

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            
            attack.Play();
            Debug.Log("attack");
        }
	}
}
