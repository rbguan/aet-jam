using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemLifeTime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    void Start()
    {
        StartCoroutine("DeleteAfterTime");
    }
    IEnumerator DeleteAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

}
