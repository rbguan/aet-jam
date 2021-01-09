using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarrelCounter : MonoBehaviour
{

    public Text counter;
    private int numBarrels = 0;
    void Start()
    {
        counter.text = "Oil Barrels Yeeted: " + numBarrels;
    }

    void OnTriggerEnter(Collider other){
        Barrel b = other.GetComponent<Barrel>();
        if(b){
            numBarrels++;
            counter.text = "Oil Barrels Yeeted: " + numBarrels;
        }
    }
}
