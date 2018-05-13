using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour {

    int startHealth;
    int currentHealth;

    // Use this for initialization
    void Start () {
        currentHealth = startHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        currentHealth -= 10;

        if (currentHealth <= 0)
        {
            Debug.Log("Dead");

            // Blow up
            Vector3 position;
            position.x = gameObject.transform.position.x;
            position.y = gameObject.transform.position.y;
            position.z = gameObject.transform.position.z;

            Collider[] hitColliders = Physics.OverlapSphere(position, 10.0f);
            int i = 0;
            while (i < hitColliders.Length)
            {
                Resource resource = hitColliders[i].gameObject.GetComponent<Resource>();

                if (resource)
                {
                    Debug.Log("This resource does exist");
                    break;
                }
                if (!resource)
                {
                    Debug.Log("This resource does not exist");
                    break;
                }

                resource.RemovePoints(50, LayerMask.NameToLayer("ExplosiveBarrel"));
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Still alive");
        }
    }
}
