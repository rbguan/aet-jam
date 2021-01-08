using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void DoAction(Vector3 playerPos){
        Debug.Log("Interacted");
    }
}
