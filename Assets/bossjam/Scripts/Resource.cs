using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {
    [SerializeField]
    public float points = 1.0f;
    public float tick = 0.02f;
    public GameObject Tears;
    public GameObject Sweat;
    CharacterMovement cm;
	// Use this for initialization
	void Start () {
        cm = GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        points -= tick * Time.deltaTime;
        points = Mathf.Clamp01(points);
        if (points == 0)
            cm.Die();
    }
    public bool IsDead()
    {
        return points == 0;
    }

    public void AddPoints(float amount)
    {
        StartCoroutine("AddPointsOverTime", amount);
    }

    void StartTearEffect()
    {
       foreach(var ps in Tears.GetComponentsInChildren<ParticleSystem>())
        {
            ps.Play();
        }
    }

    void StartSweatEffect()
    {
        foreach (var ps in Sweat.GetComponentsInChildren<ParticleSystem>())
        {
            ps.Play();
        }
    }

    IEnumerator AddPointsOverTime(float amount)
    {
        float step = 0.01f;
        while(amount > 0 && points != 1.0f)
        {
            amount -= step;
            points += step;
            points = Mathf.Clamp01(points);

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    public void RemovePoints(float amount, int hitBy)
    {
        if(points != 0)
        {
            //StartCoroutine(RemovePoints(amount));
            if(hitBy == LayerMask.NameToLayer("TearyCharacter"))
            {
                StartTearEffect();
            }

            else if(hitBy == LayerMask.NameToLayer("SweatyCharacter"))
            {
                StartSweatEffect();
            }
        }
        
    }
}
