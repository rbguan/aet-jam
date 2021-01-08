using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barrel : InteractableObject
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float explosionForce;
    public float explosionRadius;
    public float upwardsModifier;
    [Range(0,1)]
    public float explosionLerpDistance;
    public float resetTime;
    private Vector3 initialPos;
    private Quaternion initialRot;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    public override void DoAction(Vector3 playerPos)
    {
        base.DoAction(playerPos);
        Debug.Log("With Barrel");
        rb.AddExplosionForce(explosionForce, Vector3.Lerp(playerPos, transform.position, explosionLerpDistance), explosionRadius,upwardsModifier);
        StartCoroutine("ResetBarrel");
    }

    IEnumerator ResetBarrel(){
        yield return new WaitForSeconds(resetTime);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = initialRot;
        transform.position = initialPos;
    }
}
