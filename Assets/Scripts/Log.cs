﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : InteractableObject
{
    public int maxHealth;
    public int damageAmt;
    private int health;
    public int paperCount;
    public PaperCounter counter;

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
            BreakLog(); 
    }

    public void BreakLog()
    {
        counter.AddToCounter(paperCount);
        Destroy(gameObject);
    }
}
