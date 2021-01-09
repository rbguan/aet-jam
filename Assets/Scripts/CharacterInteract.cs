using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    public Animator animator;
    public float handReach = 5f;
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isSlapping")) 
        {
            animator.SetBool("isSlapping", false);
        }

        if(Input.GetButtonDown("Fire1")) 
        {
            animator.SetBool("isSlapping", true);
        }
    }

    public void TryToInteract() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, handReach))
        {
            InteractableObject objectHit = hit.transform.GetComponent<InteractableObject>();
            if(objectHit)
            {
                objectHit.DoAction(transform.position);
            }
        }
    }
}
