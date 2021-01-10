using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    public Animator animator;
    public float handReach = 5f;

    public bool hasStack = false;

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
        if (hasStack)
        {
            PaperStack stack = GetComponentInChildren<PaperStack>();
            stack.transform.parent = null;
            stack.rb.useGravity = true;
            stack.collider.enabled = true;
            hasStack = false;
            stack.LaunchStack(transform.position);
        }
        else 
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, handReach))
            {
                InteractableObject objectHit = hit.transform.GetComponent<InteractableObject>();
                if(objectHit)
                {
                    if (objectHit is PaperStack)
                        objectHit.DoAction(transform);
                    else
                        objectHit.DoAction(transform.position);
                }
            }
        }
        
    }
}
