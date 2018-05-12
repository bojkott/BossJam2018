using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionThrow : MonoBehaviour {
    public OnionSpawner OnionSpawner;
    Animator attack;
    CharacterInput input;
    
    // Use this for initialization
    void Start()
    {
        attack = GetComponent<Animator>();
        input = GetComponent<CharacterInput>();
    }

    public void ThrowOnion()
    {
        OnionSpawner.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
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
