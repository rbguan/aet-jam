using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanSplash : MonoBehaviour
{
    public GameObject particlesPrefab;
    private GameObject particles;
    // Start is called before the first frame update
 
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 12 || other.gameObject.layer != 10)
        {
            Vector3 pos = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            particles = Instantiate(particlesPrefab,pos, Quaternion.identity,null) as GameObject;
        }

    }
}
