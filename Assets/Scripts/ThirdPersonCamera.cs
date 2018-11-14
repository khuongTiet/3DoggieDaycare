using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private const float X_ANGLE_MIN = -90.0f;
    private const float X_ANGLE_MAX = 90.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 7.0f;

    private Camera cam;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitiviiyY = 1.0f;

	// Use this for initialization
	void Start () {
        camTransform = transform;
        cam = Camera.main;

	}
	
	// Update is called once per frame
	void Update () {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        currentX = Mathf.Clamp(currentX, X_ANGLE_MIN, X_ANGLE_MAX);



	}

    private void LateUpdate() {
        Vector3 dir = new Vector3(4, 0, -distance);
        Quaternion rotation = Quaternion.Euler(30, 0, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
