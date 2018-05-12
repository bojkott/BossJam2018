using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {
    [SerializeField]
    private float points = 1.0f;

    CharacterMovement cm;
	// Use this for initialization
	void Start () {
        cm = GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool IsDead()
    {
        return points == 0;
    }

    public void AddPoints(float amount)
    {
        points += amount;
        points = Mathf.Clamp01(points);
    }

    public void RemovePoints(float amount)
    {
        if(points != 0)
        {
            points -= amount;
            points = Mathf.Clamp01(points);
            if (points == 0)
                cm.Die();
        }
        
    }
}
