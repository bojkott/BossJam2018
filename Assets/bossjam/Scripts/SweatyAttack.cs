﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweatyAttack : MonoBehaviour {

    Animator attack;
    CharacterInput input;
    CharacterMovement movement;
    // Use this for initialization
    void Start () {
        attack = GetComponent<Animator>();
        input = GetComponent<CharacterInput>();
        movement = GetComponent<CharacterMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (movement.IsInAir())
        {
            return;
        }

        if (input.PressFire())
        {
            attack.SetTrigger("attack");
            Invoke("resetAttack", 1);
            
        }
	}

    void resetAttack()
    {
        attack.ResetTrigger("attack");
    }
}
