using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 offset;
    public float pitch = 2f;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float yawSpeed = 100f;
    private float yawInput = 0f;

    public int degrees = 10;

    private float currentZoom = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        //Rotate the camera as well
        RotateCamera();
    }

    void LateUpdate()
    {
        transform.position = targetToFollow.position - offset * currentZoom;
        transform.LookAt(targetToFollow.position + Vector3.up * pitch);
    }

    void RotateCamera()
    {
        if(Input.GetMouseButton(1))
        {
            transform.RotateAround(targetToFollow.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
