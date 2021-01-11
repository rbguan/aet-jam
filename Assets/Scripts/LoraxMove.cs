using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoraxMove : MonoBehaviour
{
    // Start is called before the first frame update
    private WaitForSeconds scaleIntervalWFS;
    private WaitForSeconds twitchIntervalWFS;
    private WaitForSeconds quickTwitchWFS;
    [SerializeField]
    private bool doTwitch;
    [SerializeField]
    private bool doTeleport;
    [SerializeField]
    private bool doScale;
    [SerializeField]
    private float twitchDegrees;
    [SerializeField]
    private float twitchDegreesTolerance;
    [SerializeField]
    private Transform pivotPoint;
    [SerializeField]
    private float scaleInterval;
    [SerializeField]
    private float twitchInterval;
    [SerializeField]
    private float twitchIntervalTolerance;
    [SerializeField]
    private float scaleFactor;
    [SerializeField]
    private float quickTwitchTime;
    [SerializeField]
    private float loraxYPosSubtract;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float maxScale;
    [SerializeField][Range(0,1)]
    private float minLerp;
    [SerializeField][Range(0,1)]
    private float maxLerp;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    void Start()
    {
        scaleIntervalWFS = new WaitForSeconds(scaleInterval);
        quickTwitchWFS = new WaitForSeconds(quickTwitchTime);
        if(doScale)
            StartCoroutine("ScaleUp");
        if(doTwitch)
            StartCoroutine("Twitch");
        if(doTeleport)    
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
            yield return quickTwitchWFS;
            transform.RotateAround(pivotPoint.position,pivotPoint.forward, twitchDegrees + Random.Range(-twitchDegreesTolerance, twitchDegreesTolerance));
            yield return quickTwitchWFS;
            transform.RotateAround(pivotPoint.position,pivotPoint.forward, twitchDegrees + Random.Range(-twitchDegreesTolerance, twitchDegreesTolerance));
            yield return quickTwitchWFS;
            transform.rotation = initialRotation;
            transform.position = initialPosition;
        }
    }

    IEnumerator Teleport()
    {
        for(;;)
        {
            yield return new WaitForSeconds(twitchInterval + Random.Range(-twitchIntervalTolerance, twitchIntervalTolerance));
            float lerpRand = Random.Range(minLerp,maxLerp);
            transform.position = Vector3.Lerp(player.position + (Vector3.down * loraxYPosSubtract), transform.position, lerpRand);
            yield return quickTwitchWFS;
            transform.position = initialPosition;
            yield return null;
        }
    }

}
