using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitLaunch : MonoBehaviour {

    bool isAscending;
    float ascendSpeed;
    float delay;
    float charged;

    float cooldown;
    float timeElapsed;

	// Use this for initialization
	void Start ()
    {
        isAscending = false;
        ascendSpeed = 16.0f;
        delay = 2.0f;
        charged = 0.0f;
        cooldown = 0.5f;
        timeElapsed = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timeElapsed += Time.deltaTime;
        
        Transform transform = this.gameObject.GetComponent<Transform>();

        if (isAscending)
        {
            // Ascend if not at the max height, otherwise stop ascending
            if (transform.position.y < -2.0f)
            {
                Vector3 newPos = transform.position;
                newPos.y += ascendSpeed * Time.deltaTime;
                transform.SetPositionAndRotation(newPos, transform.rotation);
            }
            else
            {
                isAscending = false;
            }
        }
        else
        {
            // Descend if not at minimum height
            if (transform.position.y > -3.5f)
            {
                Vector3 newPos = transform.position;
                newPos.y -= ascendSpeed * Time.deltaTime;
                transform.SetPositionAndRotation(newPos, transform.rotation);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (timeElapsed > cooldown)
        {
            isAscending = true;

            GameObject gameObject = col.gameObject;
            while (true)
            {
                if (gameObject.name == "Chest")
                {
                    break;
                }
                gameObject = gameObject.transform.parent.gameObject;
            }

            Rigidbody chestRigidbody = gameObject.GetComponent<Rigidbody>();

            // Apply force to chest
            gameObject.transform.parent.gameObject.GetComponent<CharacterMovement>().EnableRagDoll(0.2f);
            Vector3 force;
            force.x = 0;
            force.y = 200;
            force.z = 0;
            chestRigidbody.AddForce(force, ForceMode.VelocityChange);

            timeElapsed = 0.0f;
        }
    }
}
