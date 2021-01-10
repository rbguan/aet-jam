using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DeleteAfterTime");
    }
    IEnumerator DeleteAfterTime()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }

}
