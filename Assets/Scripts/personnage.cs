using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personnage : MonoBehaviour
{
    [SerializeField] private float speed;

    private Transform camera;
    private Rigidbody rb;
    private float v_axis;
    private float h_axis;

    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.transform.Find("camera");
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    private void Movement()
    {
        Vector3 relative_movement = new Vector3(h_axis, rb.velocity.y, v_axis) * speed;
        relative_movement = Quaternion.Euler(camera.transform.rotation.eulerAngles) * relative_movement;
        
        rb.velocity = relative_movement;
    }

    private void CameraMovement()
    {
        float h_mouse_axis = Input.GetAxis("Mouse X");

        camera.RotateAround(transform.position, new Vector3(0, 1, 0), h_mouse_axis);
    }
}
