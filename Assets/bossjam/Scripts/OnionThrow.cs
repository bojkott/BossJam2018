using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionThrow : MonoBehaviour {
    public OnionSpawner OnionSpawner;
    Animator attack;
    CharacterInput input;
    float throwForce = 0;
    bool attacking = false;
    // Use this for initialization
    void Start()
    {
        attack = GetComponent<Animator>();
        input = GetComponent<CharacterInput>();
    }

    public void ThrowOnion()
    {
        Debug.Log(throwForce);
        OnionSpawner.Spawn(throwForce * 3);
    }

    // Update is called once per frame
    void Update()
    {

        if(input.HoldFire() && !attacking)
        {
            attack.SetTrigger("charge");
            throwForce += Time.deltaTime;
        }

        if (input.ReleaseFire() && !attacking)
        {
            attack.ResetTrigger("charge");
            attack.SetTrigger("attack");
            Invoke("ThrowOnion", 0.25f);
            Invoke("resetAttack", 1);
            attacking = true;
            
        }
    }

    void resetAttack()
    {
        throwForce = 0;
        
        attack.ResetTrigger("attack");
        attacking = false;
    }
}
