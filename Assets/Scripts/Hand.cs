using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractableObject interObj = other.gameObject.GetComponent<InteractableObject>();
        if (interObj) { 
            interObj.DoAction(transform.root.position);
        }
    }
}
