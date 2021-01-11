using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Barrel : InteractableObject
{
    // Start is called before the first frame update
    Rigidbody rb;
    AudioSource source;
    public float explosionForce;
    public float explosionRadius;
    public float upwardsModifier;
    [Range(0,1)]
    public float explosionLerpDistance;
    public float resetTime;
    public float returnDistance;
    public Transform oceanTransform;
    private float oceanY;
    private Vector3 initialPos;
    private Quaternion initialRot;
    private bool interacted = false;
    private bool resetting = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        initialPos = transform.position;
        initialRot = transform.rotation;
        oceanY = oceanTransform.position.y;
    }

    void FixedUpdate() 
    {
        if(!resetting)
        {
            if(transform.position.y < oceanY)
            {
                StartCoroutine("ResetBarrel");
            }
        }
    }
    public override void DoAction(Transform playerTransform, Vector3 hitPoint)
    {
        interacted = true;
        base.DoAction(playerTransform, hitPoint);
        Vector3 playerPos = playerTransform.position;
        Debug.Log("With Barrel");
        source.Play();
        rb.AddExplosionForce(explosionForce, Vector3.Lerp(playerPos, transform.position, explosionLerpDistance), explosionRadius,upwardsModifier);
        //StartCoroutine("ResetBarrel");
    }

    IEnumerator ResetBarrel()
    {
        resetting = true;
        yield return new WaitForSeconds(resetTime);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = initialRot;
        transform.position = initialPos;
        interacted = false;
        resetting = false;
    }
}
