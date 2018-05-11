using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
public class DecalSpawner : MonoBehaviour {

    public Brush b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        
        List<ParticleCollisionEvent> collisions = new List<ParticleCollisionEvent>();
        int numCollisionEvents = ParticlePhysicsExtensions.GetCollisionEvents(GetComponent<ParticleSystem>(), other, collisions);

        for(int i=0; i < numCollisionEvents; i++)
        {
            ParticleCollisionEvent collision = collisions[i];
            InkCanvas canvas = other.GetComponent<InkCanvas>();
            if(canvas)
            {
                canvas.Paint(b, collision.intersection);
            }
        }


    }
}
