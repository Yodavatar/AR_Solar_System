using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput;
    private InputAction spaceAction;
    private Rigidbody rb;

    void Start()
    {
        spaceAction = playerInput.actions["Space"];
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spaceAction.WasPerformedThisFrame())
        {
            rb.AddForce(Vector3.up * 3, ForceMode.VelocityChange);
        }
    }
}
