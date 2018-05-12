using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : MonoBehaviour {

    public float damage = 0.1f;
    Resource resource;
    public ParticleSystem particles;
    public LayerMask canAttack;
    bool cooldown = false;
    float cooldownTimer = 0.5f;
	// Use this for initialization
	void Start () {
        resource = GetComponentInParent<Resource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ResetCooldown()
    {
        cooldown = false;
    }
    void StartCooldown()
    {
        cooldown = true;
        Invoke("ResetCooldown", cooldownTimer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!cooldown && ((1 << collision.gameObject.layer) & canAttack) != 0)
        {
            //It matched one
            Resource otherResource = collision.gameObject.GetComponentInParent<Resource>();
            if (!otherResource.IsDead())
            {
                otherResource.RemovePoints(damage);
                resource.AddPoints(damage);
                particles.Play();
                StartCooldown();
            }
            

        }
    }
}
