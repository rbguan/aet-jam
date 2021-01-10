using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoraxMove : MonoBehaviour
{
    // Start is called before the first frame update
    private WaitForSeconds scaleIntervalWFS;
    private WaitForSeconds twitchIntervalWFS;
    public float twitchDegrees;
    public float twitchDegreesTolerance;
    public Transform pivotPoint;
    public float scaleInterval;
    public float twitchInterval;
    public float twitchIntervalTolerance;
    public float scaleFactor;
    public Transform player;
    public float maxScale;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    void Start()
    {
        scaleIntervalWFS = new WaitForSeconds(scaleInterval);
        StartCoroutine("ScaleUp");
        StartCoroutine("Twitch");
        StartCoroutine("Teleport");
        initialRotation = transform.rotation;
        initialPosition = transform.position;
    }

    void Update() {
        // Vector3 vec = new Vector3(Mathf.Sin(Time.time), Mathf.Sin(Time.time), Mathf.Sin(Time.time)) * 8428;
        // transform.LookAt(player);
        // transform.localScale = vec;
    }
    IEnumerator ScaleUp()
    {
        while(transform.localScale.x < maxScale)
        {
            yield return scaleIntervalWFS;
            transform.localScale = transform.localScale * scaleFactor;
        }
    }

    IEnumerator Twitch()
    {
        for(;;)
        {
            yield return new WaitForSeconds(twitchInterval + Random.Range(-twitchIntervalTolerance, twitchIntervalTolerance));
            transform.RotateAround(pivotPoint.position,pivotPoint.forward, twitchDegrees + Random.Range(-twitchDegreesTolerance, twitchDegreesTolerance));
            yield return new WaitForSeconds(.03f);
            transform.RotateAround(pivotPoint.position,pivotPoint.forward, twitchDegrees + Random.Range(-twitchDegreesTolerance, twitchDegreesTolerance));
            yield return new WaitForSeconds(.03f);
            transform.RotateAround(pivotPoint.position,pivotPoint.forward, twitchDegrees + Random.Range(-twitchDegreesTolerance, twitchDegreesTolerance));
            yield return new WaitForSeconds(.03f);
            transform.rotation = initialRotation;
            transform.position = initialPosition;
        }
    }

    IEnumerator Teleport()
    {
        for(;;)
        {
            yield return new WaitForSeconds(twitchInterval + Random.Range(-twitchIntervalTolerance, twitchIntervalTolerance));
            float lerpRand = Random.Range(.7f,.85f);
            transform.position = Vector3.Lerp(player.position + (Vector3.down * 40), transform.position, lerpRand);
            yield return new WaitForSeconds(.03f);
            transform.position = initialPosition;
            yield return null;
        }
    }

}
