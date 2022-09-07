using UnityEngine;

public class EditorController : MonoBehaviour
{
    [SerializeField]
    private float moveByKeySpeed = 4f;
    
    [SerializeField]
    private float lookSpeedH = 2f;

    [SerializeField]
    private float lookSpeedV = 2f;

    [SerializeField]
    private float zoomSpeed = 2f;

    [SerializeField]
    private float dragSpeed = 3f;

    private float yaw = 0f;
    private float pitch = 0f;

    private void Start()
    {
        // Initialize the correct initial rotation
        this.yaw = this.transform.eulerAngles.y;
        this.pitch = this.transform.eulerAngles.x;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * moveByKeySpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * moveByKeySpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * moveByKeySpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * moveByKeySpeed;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up * Time.deltaTime * moveByKeySpeed;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.up * Time.deltaTime * moveByKeySpeed;
        }

        // Look around with Left Mouse
        if (!Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            this.yaw += this.lookSpeedH * Input.GetAxis("Mouse X");
            this.pitch -= this.lookSpeedV * Input.GetAxis("Mouse Y");

            this.transform.eulerAngles = new Vector3(this.pitch, this.yaw, 0f);
        }

        // Drag camera around with Middle Mouse
        if (Input.GetMouseButton(2))
        {
            transform.Translate(-Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed, -Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed, 0);
        }

        if (Input.GetMouseButton(1))
        {
            //Zoom in and out with Right Mouse
            this.transform.Translate(0, 0, Input.GetAxisRaw("Mouse X") * this.zoomSpeed * .07f, Space.Self);
        }

        // Zoom in and out with Mouse Wheel
        this.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * this.zoomSpeed, Space.Self);
    }
}