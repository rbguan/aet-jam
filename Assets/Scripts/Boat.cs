using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public List<Transform> wayPoints;
    public float boatSpeed;
    public float turnSpeed;
    private int currentWayPoint = 0;
    Rigidbody[] rigidbodies;
    Rigidbody rb;
    public float explosionForce;
    public float explosionRadius;
    public float upwardsModifier;
    [Range(0,1)]
    public float explosionLerpDistance;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rigidbodies = this.gameObject.GetComponentsInChildren<Rigidbody>().Where(go => go.gameObject != this.gameObject).ToArray();
        // rigidbodies = GetComponentsInChildren<Rigidbody>();
        // rb.useGravity
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != wayPoints[currentWayPoint].position){
            int lastWayPoint = (currentWayPoint + wayPoints.Count - 1) % wayPoints.Count;
            Vector3 pos = Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].position, boatSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, wayPoints[lastWayPoint].rotation, turnSpeed * Time.deltaTime);
            rb.MovePosition(pos);
        } else currentWayPoint = (currentWayPoint + 1) % wayPoints.Count;
    }

    void OnCollisionEnter(Collision other) {
        foreach(Rigidbody r in rigidbodies){
            
            r.isKinematic = false;
            r.useGravity = true;
            r.AddExplosionForce(explosionForce * Random.Range(1, 5), transform.position + Random.insideUnitSphere * explosionRadius, explosionRadius,upwardsModifier);

        }
        CapsuleCollider cc = GetComponent<CapsuleCollider>();
        BoxCollider bc = GetComponent<BoxCollider>();
        cc.enabled = false;
        bc.enabled = false;
        // Rigidbody r = rigidbodies[0];
        //     r.isKinematic = false;
        //     r.useGravity = true;
        //     r.AddExplosionForce(explosionForce, Vector3.Lerp(transform.position, r.transform.position, explosionLerpDistance), explosionRadius,upwardsModifier);
        // rb.useGravity = true;
        // rb.AddExplosionForce(explosionForce, Vector3.Lerp(other.transform.position, transform.position, explosionLerpDistance), explosionRadius,upwardsModifier);
    }
}
