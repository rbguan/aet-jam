using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : InteractableObject
{
    public int maxHealth;
    public int damageAmt;
    private int health;
    public GameObject logPrefab;
    public PaperCounter counter;
    [SerializeField]
    private GameObject treeParticle;
    [SerializeField]
    private float playerYOffset;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction(Transform playerTransform, Vector3 hitPoint)
    {
        base.DoAction(playerTransform, hitPoint);
        Vector3 playerPos = playerTransform.position;
        GameObject particles = Instantiate(treeParticle, hitPoint, Quaternion.identity) as GameObject;
        particles.transform.LookAt(playerPos);
        particles.GetComponent<ParticleSystem>().Play();
        source.Stop();
        source.Play();
        health -= damageAmt;
        if (health <= 0)
            BreakTree();
    }

    public void BreakTree()
    {
        Transform spawnPoint = transform;
        Instantiate(logPrefab, spawnPoint.position, spawnPoint.rotation).GetComponent<Log>().counter = counter;
        Instantiate(logPrefab, spawnPoint.position + transform.forward * 6.0f, spawnPoint.rotation).GetComponent<Log>().counter = counter;
        Instantiate(logPrefab, spawnPoint.position + transform.forward * 12.0f, spawnPoint.rotation).GetComponent<Log>().counter = counter;
        StartCoroutine(WaitForTreeSound());
    }

    private IEnumerator WaitForTreeSound()
    {
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(source.clip.length);
        Destroy(gameObject);
    }
}
