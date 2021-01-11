using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Boat> boats;
    public BoatCounter boatCounter;
    void Awake()
    {
        boatCounter.numBoatsStart = boats.Count;
    }
    void Start()
    {
        foreach(Boat b in boats){
            b.boatCounter = boatCounter;
            
        }
    }

}
