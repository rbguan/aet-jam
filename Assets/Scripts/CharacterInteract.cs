using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            TryToInteract();
        }
    }

    void TryToInteract() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
            InteractableObject objectHit = hit.transform.GetComponent<InteractableObject>();
            if(objectHit){
                objectHit.DoAction(transform.position);
            }
        }
    }
}
