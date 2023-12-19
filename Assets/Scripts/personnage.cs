using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    public float speed;
    public float acceleration;

    private Transform camera;
    public Rigidbody rb;
    public float v_axis;
    public float h_axis;

    public Vector3 relative_movement;

    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.transform.Find("camera");
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		rb.freezeRotation = true;
	}

    // Update is called once per frame
    void Update()
    {
        v_axis = Input.GetAxis("Vertical");
        h_axis = Input.GetAxis("Horizontal");

        CameraMovement();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        relative_movement = new Vector3(h_axis, 0, v_axis) * acceleration;
        relative_movement = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, camera.transform.rotation.eulerAngles.z) * relative_movement;

        relative_movement.y = rb.velocity.y;
        
        rb.velocity = relative_movement;
    }

    private void CameraMovement()
    {
        float h_mouse_axis = Input.GetAxis("Mouse X");

        camera.RotateAround(transform.position, new Vector3(0, 1, 0), h_mouse_axis);
    }
}
