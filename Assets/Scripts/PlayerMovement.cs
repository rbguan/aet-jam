using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 
    public float maxJumpSpeed = 50f;
    [SerializeField] private CharacterController myController;
    [SerializeField] private float mySpeed = 10f;
    [SerializeField] private float myGravity = -9f;
    [SerializeField] private float myGroundCheckDist = .2f;
    [SerializeField] private float myHeadCheckDist = .2f;
    [SerializeField][Range(0,1)] private float myAirControl;
    [SerializeField] private Transform myGroundChecker;
    [SerializeField] private Transform myHeadChecker;
    [SerializeField] private LayerMask myGroundMask;
    [SerializeField] private float myJumpHeight;
    private float leftRight = 0f;
    private float forwardBack = 0f;
    private float jump = 0f;
    private Vector3 myVelocity = Vector3.zero;
    private bool onGround = false;
    private bool hittingHead;
    private bool isJumping = false;
    
    void Update()
    {
        leftRight = Input.GetAxis("Horizontal");
        forwardBack = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
    }

    void FixedUpdate() 
    {
        onGround = Physics.CheckSphere(myGroundChecker.position, myGroundCheckDist, myGroundMask);
        hittingHead = Physics.CheckSphere(myHeadChecker.position, myHeadCheckDist, myGroundMask);
        if(onGround){
            Debug.Log("On Ground");
        }
        Vector3 movement = transform.right * leftRight + transform.forward * forwardBack;
        myVelocity.y += myGravity;
        if(!onGround){
            myController.Move(movement * mySpeed * myAirControl);
        }else{
            myController.Move(movement * mySpeed);
        }
        
        
        if(onGround && myVelocity.y < 0){
            myVelocity.y = -.5f;
            isJumping = false;
            // myFallWarning.SetJump(false);
        }
        if(onGround && jump > 0){
            myVelocity.y += Mathf.Sqrt(myJumpHeight * -2 * myGravity);
            isJumping = true;
            // myFallWarning.SetJump(true);
        }
        if(hittingHead && myVelocity.y > 0){
           myVelocity.y = 0f; 
        }
        if(myVelocity.y > maxJumpSpeed){
            myVelocity.y = maxJumpSpeed;
        }
        // Debug.Log( myVelocity.y);
        myController.Move(myVelocity * Time.deltaTime);
    }
}
