using UnityEngine;
using System.Collections;

public class CharacterMaintainHeight : MonoBehaviour
{
    new protected Rigidbody rigidbody;
    public float desiredHeight = 1;
    public float pullUpForce = 10;
    public float leadTime = 0.3f; // *** THIS IS USED TO SLOW DOWN WHEN APPROACHING THE DESIRED HEIGHT, INSTEAD OF OVERSHOOTING BACK AND FORTH **
    public Transform inRelationTo = null;
    public Transform offset = null;
    //
    protected float groundHeight = 0;
    RaycastHit groundHit;
    //
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // ***** TRY HOLD A OBJECT AT A SPECIFIC HEIGHT (optionally in relation to another object) ***
        //
        Vector3 pos = transform.position;
        if (offset)
            pos = offset.position;
        if (Physics.Raycast(new Ray(pos, Vector3.down), out groundHit, 100, 1 << LayerMask.NameToLayer("Ground")))
        {
            groundHeight = groundHit.point.y;
            
        }

        float diff = (groundHeight + desiredHeight) - (transform.position.y + rigidbody.velocity.y * leadTime);
        if (inRelationTo != null)
        {
            diff = inRelationTo.TransformPoint(Vector3.up * desiredHeight).y - (transform.position.y + rigidbody.velocity.y * leadTime);
        }
        float dist = Mathf.Abs(diff);
        float pullM = Mathf.Clamp01(dist / 0.3f);
        rigidbody.AddForce(new Vector3(0, Mathf.Sign(diff) * pullUpForce * pullM * Time.deltaTime, 0), ForceMode.Impulse);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundHit.point, 0.2f);
    }
}
