using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    public float sensitivity = 2f;
    [SerializeField] private Transform myPlayer;
    private float verticalRotation = 0f;
    private float myMouseX = 0f;
    private float myMouseY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        myMouseX = Input.GetAxis("Mouse X") * sensitivity;
        myMouseY = Input.GetAxis("Mouse Y") * sensitivity;
    }

    void FixedUpdate() 
    {
        verticalRotation -= myMouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        myPlayer.Rotate(Vector3.up * myMouseX);
    }
}
