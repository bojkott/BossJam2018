using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionDamage : MonoBehaviour {

    public float force = 10;
    public float damage = 0.1f;
    public LayerMask canAttack;
    Resource resource;
    List<int> hitObjects = new List<int>();
	// Use this for initialization
	void Start () {
        resource = GameObject.FindGameObjectWithTag("Teary").GetComponent<Resource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(((1 << other.gameObject.layer) & canAttack) != 0)
        {
            if(!hitObjects.Contains(other.gameObject.layer))
            {
                Resource otherResource = other.gameObject.GetComponentInParent<Resource>();
                if (!otherResource.IsDead())
                {
                    otherResource.RemovePoints(damage, LayerMask.NameToLayer("TearyCharacter"));
                    resource.AddPoints(damage);
                    hitObjects.Add(other.gameObject.layer);
                }
            }
            other.gameObject.GetComponentInParent<Rigidbody>().AddExplosionForce(force, transform.position, transform.localScale.magnitude);
        }
    }
}
