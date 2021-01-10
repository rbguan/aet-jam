using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStack : InteractableObject
{
    public Rigidbody rb;
    public Collider collider;
    public float explosionForce;
    public float explosionRadius;
    public float upwardsModifier;
    [Range(0, 1)]
    public float explosionLerpDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction(Transform playerTransform)
    {
        base.DoAction(playerTransform);

        transform.parent = playerTransform;
        playerTransform.gameObject.GetComponent<CharacterInteract>().hasStack = true;
        rb.useGravity = false;
        collider.enabled = false;
    }

    public void LaunchStack(Vector3 playerPos)
    {
        rb.AddExplosionForce(explosionForce, Vector3.Lerp(playerPos, transform.position, explosionLerpDistance), explosionRadius, upwardsModifier);

    }
}
