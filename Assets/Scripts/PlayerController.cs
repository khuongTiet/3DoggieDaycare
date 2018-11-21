using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float moveSpeed;
    public float turnSpeed = 150f;
    private CharacterController characterController;
    Animator anim;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        mainCamera = FindObjectOfType<Camera>();

	}

	
	// Update is called once per frame
	void FixedUpdate () {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if (vertical != 0.0f) {
            characterController.SimpleMove(transform.forward * moveSpeed * vertical);
        }

        //characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        //if (movement.magnitude > 0) {
        //    Quaternion newDirection = Quaternion.LookRotation(movement);

        //    transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        //} 
        Animating(horizontal, vertical);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
