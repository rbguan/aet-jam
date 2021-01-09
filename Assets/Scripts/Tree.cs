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
    public Text paperText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoAction(Vector3 playerPos)
    {
        base.DoAction(playerPos);
        health -= damageAmt;
        if (health <= 0)
            BreakTree();
    }

    public void BreakTree()
    {
        Transform spawnPoint = transform;
        Instantiate(logPrefab, spawnPoint.position, spawnPoint.rotation).GetComponent<Log>().paperText = paperText;
        Instantiate(logPrefab, spawnPoint.position + transform.forward * 5.0f, spawnPoint.rotation).GetComponent<Log>().paperText = paperText;
        Instantiate(logPrefab, spawnPoint.position + transform.forward * 10.0f, spawnPoint.rotation).GetComponent<Log>().paperText = paperText;
        Destroy(gameObject);
    }
}
