using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitLaunch : MonoBehaviour {

    bool isAscending;
    bool isCollidingWithCharacter;
    float ascendSpeed;
    float delay;
    float charged;

    float cooldown;
    float timeElapsed;

	// Use this for initialization
	void Start ()
    {
        isAscending = false;
        isCollidingWithCharacter = false;
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

        // Begin charging launch pad if the delay time is not achieved, otherwise begin ascending
        //if (isCollidingWithCharacter)
        //{
        //    charged += Time.deltaTime;
        //    if (charged < delay)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        charged = 0.0f;
        //        isCollidingWithCharacter = false;
        //        isAscending = true;
        //    }
        //}
	}

    void OnCollisionEnter(Collision col)
    {
        if (timeElapsed > cooldown)
        {
            //isCollidingWithCharacter = true;
            isAscending = true;

            //Rigidbody chestRigidbody;

            //Debug.Log(col.gameObject);

            //GameObject gameObject = col.gameObject;
            //while (true)
            //{
            //    if (gameObject.tag == "Character")
            //    {
            //    }
            //    gameObject = gameObject.transform.parent.gameObject;
            //}


            //if (col.gameObject.name == "Chest")
            //{
            //    // The chest was the colliding object
            //    chestRigidbody = col.gameObject.GetComponent<Rigidbody>();
            //}
            //else
            //{
            //    ConfigurableJoint joint = col.gameObject.GetComponent<ConfigurableJoint>();

                
            //    // Switch joint until chest is reached
            //    while (true)
            //    {
            //        if (joint.connectedBody.gameObject.name == "Chest")
            //        {
            //            chestRigidbody = joint.connectedBody;
            //            break;
            //        }

            //        joint = joint.connectedBody.gameObject.GetComponent<ConfigurableJoint>();
            //    }
            //}

            //// Apply force to chest
            //Vector3 force;
            //force.x = 0; force.y = 250; force.z = 0;
            //chestRigidbody.AddForce(force, ForceMode.VelocityChange);

            //timeElapsed = 0.0f;
        }

       

        //if (col.gameObject.name == "SweatyCharacter")
        //{
        //    Transform transform = this.gameObject.GetComponent<Transform>();
        //    Vector3 newPos;
        //    newPos.x = transform.position.x;
        //    newPos.y = transform.position.y + 10;
        //    newPos.z = transform.position.z;
        //
        //    transform.SetPositionAndRotation(newPos, transform.rotation);
        //}
        //
        //if (col.gameObject.layer == 12 /*"SweatyCharacter"*/)
        //{
        //    Transform transform = this.gameObject.GetComponent<Transform>();
        //    Vector3 newPos;
        //    newPos.x = transform.position.x;
        //    newPos.y = transform.position.y + 10;
        //    newPos.z = transform.position.z;
        //
        //    transform.SetPositionAndRotation(newPos, transform.rotation);
        //}
        //
        //if (col.gameObject.tag == "SweatyCharacter")
        //{
        //    Transform transform = this.gameObject.GetComponent<Transform>();
        //    Vector3 newPos;
        //    newPos.x = transform.position.x;
        //    newPos.y = transform.position.y + 10;
        //    newPos.z = transform.position.z;
        //
        //    transform.SetPositionAndRotation(newPos, transform.rotation);
        //}
    }
}
