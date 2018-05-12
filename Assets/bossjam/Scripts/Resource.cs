using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {
    [SerializeField]
    public float points = 1.0f;

    public GameObject Tears;
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

    void StartTearEffect()
    {
       foreach(var ps in Tears.GetComponentsInChildren<ParticleSystem>())
        {
            ps.Play();
        }
    }

    IEnumerator RemovePoints(float amount)
    {
        float step = 0.01f;
        while(amount > 0)
        {
            amount -= step;
            points -= step;
            points = Mathf.Clamp01(points);
            if (points == 0)
                cm.Die();

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    public void RemovePoints(float amount, int hitBy)
    {
        if(points != 0)
        {
            StartCoroutine(RemovePoints(amount));
            if(hitBy == LayerMask.NameToLayer("TearyCharacter"))
            {
                StartTearEffect();
            }

        }
        
    }
}
