using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargetCamera : MonoBehaviour {

    public List<string> tags;
    private List<Transform> targets = new List<Transform>();
    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime = .5f;
    public float minZoom = 40.0f;
    public float maxZoom = 10.0f;
    public float zoomLimiter = 20.0f;

    Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        targets.Clear();
        foreach(string t in tags)
        {
           targets.Add(GameObject.FindGameObjectWithTag(t).transform.Find("Chest"));
        }
        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        Bounds b = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            b.Encapsulate(targets[i].position);
        }
        return b.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
            return targets[0].position;

        Bounds b = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0; i < targets.Count; i++)
        {
            b.Encapsulate(targets[i].position);
        }
        return b.center;
    }
}
