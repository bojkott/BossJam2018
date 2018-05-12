using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphone : MonoBehaviour {

    public float force = 10f;
    public float speed = 1.0f;
    public float damage = 0.1f;
    Resource resource;
    public LayerMask canAttack;

    ParticleSystem ps;
    List<int> hitObjects = new List<int>();
    // Use this for initialization
    void Start () {
        resource = GameObject.FindGameObjectWithTag("Sweaty").GetComponent<Resource>();
        ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, 5);
    }



    // Update is called once per frame
    void Update () {
        Vector3 forward = transform.forward;
        forward.y = 0;

        transform.position += forward.normalized * speed;
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & canAttack) != 0)
        {
            if (!hitObjects.Contains(other.gameObject.layer))
            {
                Resource otherResource = other.gameObject.GetComponentInParent<Resource>();
                if (!otherResource.IsDead())
                {
                    otherResource.RemovePoints(damage, LayerMask.NameToLayer("SweatyCharacter"));
                    resource.AddPoints(damage);
                    hitObjects.Add(other.gameObject.layer);
                }
            }
            other.gameObject.GetComponentInParent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}
